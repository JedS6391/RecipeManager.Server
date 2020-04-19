using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Exceptions;
using RecipeManager.Core.Features.Cart.Commands.Requests;
using RecipeManager.Core.Features.Cart.Models.Query;
using RecipeManager.Core.Infrastructure.Abstract;

namespace RecipeManager.Core.Features.Cart.Commands.Validation
{
    /// <summary>
    /// A command request validator for <see cref="AddIngredientsToCurrentCartRequest"/> requests.
    /// </summary>
    public class AddIngredientsToCurrentCartCommandRequestValidator
        : ICommandRequestValidator<AddIngredientsToCurrentCartRequest, CartModel>
    {
        private readonly IRecipeDomainContext _recipeDomainContext;
        
        public AddIngredientsToCurrentCartCommandRequestValidator(IRecipeDomainContext recipeDomainContext)
        {
            _recipeDomainContext = recipeDomainContext;
        }
        
        public Task Validate(AddIngredientsToCurrentCartRequest request)
        {
            var ingredientIds = new HashSet<Guid>(
                request.Ingredients.Select(i => i.IngredientId));

            var ingredientRecipes = _recipeDomainContext
                .Ingredients
                .Include(i => i.Recipe)
                .Where(i => ingredientIds.Contains(i.Id))
                .Select(i => i.Recipe);

            if (ingredientRecipes.Any(r => r.UserId != request.User.Id))
            {    
                ThrowValidationError(ValidationErrors.IngredientDoesNotBelongToOneOfUsersRecipes);
            }

            return Task.CompletedTask;
        }
        
        private void ThrowValidationError(params string[] validationErrors)
        {
            throw new ValidationException("Unable to add ingredients to cart due to failed validations.", validationErrors);
        }

        private static class ValidationErrors
        {
            public static string IngredientDoesNotBelongToOneOfUsersRecipes = $"{nameof(AddIngredientsToCurrentCartRequest)}:ingredient-does-not-belong-to-users-recipes";
        }
    }
}