using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Infrastructure.Abstract;

namespace RecipeManager.Core.Features.Recipes.Commands.Handlers
{
    /// <summary>
    /// Handles all <see cref="DeleteRecipeByIdRequest"/> requests.
    /// </summary>
    public class DeleteRecipeByIdCommandHandler 
        : BaseCommandHandler<DeleteRecipeByIdRequest, Unit>
    {
        public DeleteRecipeByIdCommandHandler(IRecipeDomainContext recipeDomainContext)
            : base(recipeDomainContext)
        { }

        public override async Task<Unit> Handle(DeleteRecipeByIdRequest request, CancellationToken cancellationToken)
        {
            var recipeToRemove = await RecipeDomainContext
                .Recipes
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.UserId == request.User.Id && r.Id == request.RecipeId);

            if (recipeToRemove != null)
            {
                // First, remove any cart items associated with ingredients from this recipe.
                var ingredientIds = new HashSet<Guid>(
                    recipeToRemove.Ingredients.Select(i => i.Id));
                var cart = await RecipeDomainContext
                    .Carts
                    .Include(c => c.Items)
                    .ThenInclude(ci => ci.Ingredient)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefaultAsync(c => c.UserId == request.User.Id && c.IsCurrent);

                cart.Items = cart.Items.Where(ci => !ingredientIds.Contains(ci.Ingredient.Id)).ToList();
                
                // Now, delete the recipe.
                RecipeDomainContext.Recipes.Remove(recipeToRemove);

                await RecipeDomainContext.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}