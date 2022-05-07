using System;

namespace RecipeManager.Core.Features.Recipes.Commands.Requests
{
    /// <summary>
    /// Represents a command to update a <see cref="Recipe"/>.
    /// </summary>
    public class UpdateRecipeRequest : CreateRecipeRequest
    {
        /// <summary>
        /// Gets or sets the ID of the recipe.
        /// </summary>
        public Guid RecipeId { get; set; }
    }
}
