using System;
using System.Collections.Generic;
using RecipeManager.Domain.Entities.Abstract;

namespace RecipeManager.Domain.Entities
{
    /// <summary>
    /// Represents a category of an <see cref="Ingredient"/>.
    /// </summary>
    public class IngredientCategory : IIdentifiable<Guid>
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; private set; }
        
        /// <summary>
        /// Gets the identifier of the user this category belongs to.
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// Gets the name of the category.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the ingredients that this category is linked to.
        /// </summary>
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}