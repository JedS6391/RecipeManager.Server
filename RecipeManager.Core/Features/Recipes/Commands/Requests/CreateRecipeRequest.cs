using MediatR;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Commands.Requests
{
    /// <summary>
    /// Represents a command request to create a new <see cref="Recipe"/> for a given user.
    /// </summary>
    public class CreateRecipeRequest : IRequest<RecipeModel>
    {
        /// <summary>
        /// Gets or sets the name of the recipe to create.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user creating this recipe.
        /// </summary>
        public User User { get; set; }
    }
}
