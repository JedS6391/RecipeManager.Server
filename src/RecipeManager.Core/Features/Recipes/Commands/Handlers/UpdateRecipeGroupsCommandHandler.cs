using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Data.Extensions;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Features.Recipes.Exceptions;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Core.Infrastructure.Abstract;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Commands.Handlers
{
    /// <summary>
    /// Handles all <see cref="UpdateRecipeGroupsRequest"/> requests.
    /// </summary>
    public class UpdateRecipeGroupsCommandHandler
        : BaseValidatingCommandHandler<UpdateRecipeGroupsRequest, RecipeModel>
    {
        public UpdateRecipeGroupsCommandHandler(
            IRecipeDomainContext recipeDomainContext, 
            IEnumerable<ICommandRequestValidator<UpdateRecipeGroupsRequest, RecipeModel>> commandRequestValidators) 
            : base(recipeDomainContext, commandRequestValidators)
        {
        }

        /// <inheritdoc/>
        public override async Task<RecipeModel> DoHandleRequest(UpdateRecipeGroupsRequest request, CancellationToken cancellationToken)
        {
            var recipe = await RecipeDomainContext
                .GetRecipesForUser(request.User)
                .FirstOrDefaultAsync(r => r.Id == request.RecipeId);

            if (recipe == null)
            {
                throw new RecipeNotFoundException($"No recipe found [ID = {request.RecipeId}]");
            }
            
            // First, create any new recipe groups.
            var newRecipeGroups = await CreateNewRecipeGroups(request);

            // Now, update the recipe group links
            recipe.RecipeGroupLinks = newRecipeGroups.Select(rg => new RecipeGroupLink()
            {
                RecipeId = recipe.Id,
                RecipeGroupId = rg.Id
            }).ToList();

            foreach (var recipeGroup in request.RecipeGroupsToAssociate)
            {
                recipe.RecipeGroupLinks.Add(new RecipeGroupLink()
                {
                    RecipeId = recipe.Id,
                    RecipeGroupId = recipeGroup.RecipeGroupId
                });
            }

            await RecipeDomainContext.SaveChangesAsync();
            
            // Refresh data
            recipe = await RecipeDomainContext
                .GetRecipesForUser(request.User)
                .FirstOrDefaultAsync(r => r.Id == request.RecipeId);
            
            return RecipeModel.From(recipe);
        }

        private async Task<IEnumerable<RecipeGroup>> CreateNewRecipeGroups(UpdateRecipeGroupsRequest request)
        {
            var newRecipeGroups = new List<RecipeGroup>();
            
            foreach (var recipeGroup in request.RecipeGroupsToCreate)
            {
                var newRecipeGroup = new RecipeGroup()
                {
                    Name = recipeGroup.Name,
                    UserId = request.User.Id
                };
                
                await RecipeDomainContext.RecipeGroups.AddAsync(newRecipeGroup);

                newRecipeGroups.Add(newRecipeGroup);
            }

            return newRecipeGroups;
        } 
    }
}