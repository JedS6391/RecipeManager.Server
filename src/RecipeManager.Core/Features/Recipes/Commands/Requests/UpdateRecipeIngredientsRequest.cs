using System;
using System.Collections.Generic;
using MediatR;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Core.Features.Recipes.Models.Command;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Commands.Requests
{
    /// <summary>
    /// Represents a command to update the <see cref="Recipe.Ingredients"/> of a <see cref="Recipe"/>.
    /// </summary>
    public class UpdateRecipeIngredientsRequest : IRequest<RecipeModel>
    {
        /// <summary>
        /// Gets or sets the ID of the recipe to update.
        /// </summary>
        public Guid RecipeId { get; set; }

        /// <summary>
        /// Gets or sets the new ingredient list.
        /// </summary>
        public IEnumerable<IngredientCreateModel> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the user the recipe belongs to.
        /// </summary>
        public User User { get; set; }
    }
}
