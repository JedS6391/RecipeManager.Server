using MediatR;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Commands.Requests
{
    /// <summary>
    /// Defines a request to import a recipe.
    /// </summary>
    public class ImportRecipeRequest : IRequest<RecipeImportJobModel>
    {
        /// <summary>
        /// Gets or sets the URL where the recipe details can be retreived from.
        /// </summary>
        public string RecipeUrl { get; set; }
        
        /// <summary>
        /// Gets or sets the user to import the recipe for.
        /// </summary>
        public User User { get; set; }
    }
}