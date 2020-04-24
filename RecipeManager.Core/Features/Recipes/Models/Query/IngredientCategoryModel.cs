using System;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Models.Query
{
    /// <summary>
    /// Defines a read-only view of an <see cref="IngredientCategory"/>.
    /// </summary>
    public class IngredientCategoryModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creates an <see cref="IngredientCategoryModel"/> instance from the given <see cref="IngredientCategory"/>.
        /// </summary>
        /// <param name="ingredientCategory">An ingredient category.</param>
        /// <returns>A read-only view of the given ingredient category.</returns>
        public static IngredientCategoryModel From(IngredientCategory ingredientCategory)
        {
            if (ingredientCategory == null)
            {
                return null;
            }
            
            return new IngredientCategoryModel()
            {
                Id = ingredientCategory.Id,
                Name = ingredientCategory.Name
            };
        }
    }
}