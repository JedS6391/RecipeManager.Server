using System;
using System.Collections.Generic;
using RecipeManager.Domain.Entities.Abstract;

namespace RecipeManager.Domain.Entities
{
    /// <summary>
    /// Represents a recipe.
    /// </summary>
    /// <remarks>A recipe is composed of a collection of ingredients and instructions.</remarks>
    public class Recipe : IIdentifiable<Guid>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ingredients.
        /// </summary>
        public ICollection<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        public ICollection<Instruction> Instructions { get; set; }
    }
}
