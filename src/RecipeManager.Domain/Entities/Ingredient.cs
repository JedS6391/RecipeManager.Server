using System;
using System.Collections.Generic;
using RecipeManager.Domain.Entities.Abstract;

namespace RecipeManager.Domain.Entities
{
    /// <summary>
    /// Represents an ingredient of a <see cref="Entities.Recipe"/>.
    /// </summary>
    public class Ingredient : IIdentifiable<Guid>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets or sets the recipe identifier.
        /// </summary>
        public Guid RecipeId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the amount of this ingredient.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the optional category identifier.
        /// </summary>
        public Guid? CategoryId { get; set; }
        
        /// <summary>
        /// Gets or sets the recipe that this ingredient is for.
        /// </summary>
        public Recipe Recipe { get; set; }
        
        /// <summary>
        /// Gets or sets the category of this ingredient.
        /// </summary>
        public IngredientCategory Category { get; set; }
    }
}
