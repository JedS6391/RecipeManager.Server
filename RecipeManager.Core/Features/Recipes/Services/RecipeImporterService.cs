using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Services.Abstract;
using RecipeManager.Core.Queue.Contracts;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Services
{
    /// <summary>
    /// An implementation of <see cref="IRecipeImporterService"/> that will
    /// fetch the recipe content and parse a recipe from the JSON-LD information if any.
    /// </summary>
    public class RecipeImporterService : IRecipeImporterService
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private readonly ILogger<RecipeImporterService> _logger;
        private readonly IRecipeDomainContext _recipeDomainContext;
        
        public RecipeImporterService(
            ILogger<RecipeImporterService> logger,
            IRecipeDomainContext recipeDomainContext)
        {
            _logger = logger;
            _recipeDomainContext = recipeDomainContext;
        }
        
        public async Task ImportRecipe(ImportRecipeMessage importRecipeMessage)
        {
            try
            {
                _logger.LogDebug($"Attempting to import recipe from {importRecipeMessage.RecipeUrl} for {importRecipeMessage.UserId}");

                var rawPageContent = await HttpClient.GetStringAsync(importRecipeMessage.RecipeUrl);

                _logger.LogTrace($"Successfully fetched content from {importRecipeMessage.RecipeUrl}");
                
                if (TryExtractRecipe(rawPageContent, out var recipe))
                {
                    _logger.LogTrace($"Successfully extracted recipe from {importRecipeMessage.RecipeUrl}");
                    
                    recipe.UserId = importRecipeMessage.UserId;

                    await _recipeDomainContext.Recipes.AddAsync(recipe);

                    await _recipeDomainContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                // TODO: logging
                throw;
            }
        }

        private bool TryExtractRecipe(string rawPageContent, out Recipe recipe)
        {
            // The logic below is based on the assumption that the website is
            // using the format described here: https://developers.google.com/search/docs/data-types/recipe
            var pageContent = new HtmlDocument();
                
            pageContent.LoadHtml(rawPageContent);

            var jsonLdScriptNode = pageContent
                .DocumentNode
                .SelectSingleNode("//script[@type='application/ld+json']");

            var jsonLd = jsonLdScriptNode.InnerText;
            var json = JObject.Parse(jsonLd);

            if (json.TryGetValue("@graph", out var graphToken))
            {
                var graphArray = graphToken as JArray;

                if (graphArray == null)
                {
                    // TODO
                    throw new Exception();
                }

                var graphObjects = graphArray.Children<JObject>();
                var recipeData = graphObjects
                    .FirstOrDefault(o => (string) (o["@type"] as JValue) == "Recipe");

                if (recipeData == null)
                {
                    // TODO
                    throw new Exception();
                }
                
                var recipeName = recipeData["name"];
                var recipeIngredients = recipeData["recipeIngredient"];

                recipe = new Recipe()
                {
                    Name = recipeName.Value<string>(),
                    Ingredients = recipeIngredients.Select(t => new Ingredient()
                    {
                        Name = t.Value<string>(),
                        
                        // TODO: How to extract amount?
                    }).ToList(),
                    Instructions = new Instruction[] { },
                    RecipeGroupLinks = new RecipeGroupLink[] { }
                };

                return true;
            }

            recipe = null;
            
            return false;
        }
    }
}