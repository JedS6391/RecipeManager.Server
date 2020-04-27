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
    /// Handles all <see cref="UpdateRecipeIngredientsRequest"/> requests.
    /// </summary>
    public class UpdateRecipeIngredientsCommandHandler
        : BaseValidatingCommandHandler<UpdateRecipeIngredientsRequest, RecipeModel>
    {
        public UpdateRecipeIngredientsCommandHandler(
            IRecipeDomainContext recipeDomainContext,
            IEnumerable<ICommandRequestValidator<UpdateRecipeIngredientsRequest, RecipeModel>> commandRequestValidators)
            : base(recipeDomainContext, commandRequestValidators)
        {
        }

        public override async Task<RecipeModel> DoHandleRequest(UpdateRecipeIngredientsRequest request, CancellationToken cancellationToken)
        {
            var recipe = await RecipeDomainContext
                .GetRecipesForUser(request.User)
                .FirstOrDefaultAsync(r => r.Id == request.RecipeId);

            var existingIngredientCategories = await RecipeDomainContext
                .IngredientCategories
                .ForUser(request.User)
                .ToListAsync();
            
            if (recipe == null)
            {
                throw new RecipeNotFoundException($"No recipe found [ID = {request.RecipeId}]");
            }

            var ingredients = request.Ingredients.Select(i => new Ingredient()
            {
                RecipeId = request.RecipeId,
                Name = i.Name,
                Amount = i.Amount,
                // Try to find the existing category, creating a new one if none is found.
                Category = existingIngredientCategories
                    .FirstOrDefault(ic => ic.Name == i.Category) ??
                           new IngredientCategory()
                           {
                               Name = i.Category,
                               UserId = request.User.Id
                           }
            });

            recipe.Ingredients = ingredients.ToList();

            await RecipeDomainContext.SaveChangesAsync();

            return RecipeModel.From(recipe);
        }
    }
}
