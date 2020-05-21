using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RecipeIngredientParser.Core.Parser;
using RecipeIngredientParser.Core.Parser.Extensions;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Services.Abstract;
using RecipeManager.Core.Queue.Contracts;
using RecipeManager.Domain.Entities;
using RecipeManager.Domain.Entities.Enum;

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
        private readonly Lazy<IngredientParser> _ingredientParser;
        
        public RecipeImporterService(
            ILogger<RecipeImporterService> logger,
            IRecipeDomainContext recipeDomainContext)
        {
            _logger = logger;
            _recipeDomainContext = recipeDomainContext;
            _ingredientParser = new Lazy<IngredientParser>(GetIngredientParser);
        }
        
        public async Task ImportRecipe(ImportRecipeMessage importRecipeMessage)
        {
            try
            {
                _logger.LogDebug($"Attempting to import recipe from {importRecipeMessage.RecipeUrl} for {importRecipeMessage.UserId}");

                await UpdateJobStatus(importRecipeMessage.JobId, RecipeImportJobStatus.Started);
                
                var rawPageContent = await HttpClient.GetStringAsync(importRecipeMessage.RecipeUrl);

                _logger.LogTrace($"Successfully fetched content from {importRecipeMessage.RecipeUrl}");
                
                if (TryExtractRecipeData(rawPageContent, out var recipeData))
                {
                    _logger.LogTrace($"Successfully extracted recipe from {importRecipeMessage.RecipeUrl}");

                    var defaultIngredientCategory = await GetDefaultIngredientCategory(importRecipeMessage.UserId);
                    
                    var recipe = new Recipe()
                    {
                        Name = recipeData.Name,
                        UserId = importRecipeMessage.UserId,
                        Ingredients = recipeData
                            .Ingredients
                            .Select(i => DetermineIngredient(i, defaultIngredientCategory))
                            .ToList(),
                        Instructions = new Instruction[] { },
                        RecipeGroupLinks = new RecipeGroupLink[] { }
                    };

                    await _recipeDomainContext.Recipes.AddAsync(recipe);

                    await _recipeDomainContext.SaveChangesAsync();

                    await AssociateRecipeToJob(recipe, importRecipeMessage.JobId);
                    
                    await UpdateJobStatus(importRecipeMessage.JobId, RecipeImportJobStatus.Completed);
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unhandled exception during recipe import processing.");

                await UpdateJobStatus(importRecipeMessage.JobId, RecipeImportJobStatus.Failed);
                
                throw;
            }
        }

        private async Task UpdateJobStatus(Guid jobId, RecipeImportJobStatus newStatus)
        {
            var job = await _recipeDomainContext.RecipeImportJobs.FirstAsync(j => j.Id == jobId);

            job.Status = newStatus;

            await _recipeDomainContext.SaveChangesAsync();
        }

        private async Task AssociateRecipeToJob(Recipe recipe, Guid jobId)
        {
            var job = await _recipeDomainContext.RecipeImportJobs.FirstAsync(j => j.Id == jobId);

            job.ImportedRecipeId = recipe.Id;

            await _recipeDomainContext.SaveChangesAsync();
        }

        private bool TryExtractRecipeData(string rawPageContent, out ExtractedRecipeData recipe)
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

                recipe = new ExtractedRecipeData()
                {
                    Name = recipeName.Value<string>(),
                    Ingredients = recipeIngredients.Select(t => t.Value<string>()).ToList()
                };
                
                return true;
            }

            recipe = null;
            
            return false;
        }

        private Ingredient DetermineIngredient(string ingredient, IngredientCategory category)
        {
            if (_ingredientParser.Value.TryParseIngredient(ingredient, out var parseResult))
            {
                return new Ingredient()
                {
                    Name = parseResult.Details.Ingredient ?? string.Empty,
                    CategoryId = category.Id,
                    Amount = $"{parseResult.Details.Amount ?? string.Empty} {parseResult.Details.Unit ?? string.Empty}"
                };
            }
            
            return new Ingredient()
            {
                Name = ingredient,
                CategoryId = category.Id,
                Amount = string.Empty
            };
        }
        
        private async Task<IngredientCategory> GetDefaultIngredientCategory(string userId)
        {
            var defaultIngredientCategory = _recipeDomainContext
                .IngredientCategories
                .FirstOrDefault(ic => ic.Name == "Default");

            if (defaultIngredientCategory == null)
            {
                // Create the default ingredient category
                await _recipeDomainContext.IngredientCategories.AddAsync(new IngredientCategory()
                {
                    Name = "Default",
                    UserId = userId,
                    Ingredients = new Ingredient[] { }
                });

                await _recipeDomainContext.SaveChangesAsync();
            }

            return defaultIngredientCategory;
        }

        private IngredientParser GetIngredientParser()
        {
            return IngredientParser
                .Builder
                .New
                .WithDefaultConfiguration()
                .Build();
        }

        private class ExtractedRecipeData
        {
            public string Name { get; set; }
            public IEnumerable<string> Ingredients { get; set; }
        }
    }
}