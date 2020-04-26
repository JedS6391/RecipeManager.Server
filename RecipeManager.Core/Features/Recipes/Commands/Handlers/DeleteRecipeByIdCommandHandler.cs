using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Data.Extensions;
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
                .GetRecipesForUser(request.User)
                .FirstOrDefaultAsync(r => r.Id == request.RecipeId);

            if (recipeToRemove != null)
            {
                // First, remove any cart items associated with ingredients from this recipe.
                var ingredientIds = new HashSet<Guid>(
                    recipeToRemove.Ingredients.Select(i => i.Id));
                var cart = await RecipeDomainContext.GetCurrentCart(request.User);

                cart.Items = cart.Items.Where(ci => !ingredientIds.Contains(ci.Ingredient.Id)).ToList();
                
                // Now, delete the recipe.
                RecipeDomainContext.Recipes.Remove(recipeToRemove);

                await RecipeDomainContext.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}