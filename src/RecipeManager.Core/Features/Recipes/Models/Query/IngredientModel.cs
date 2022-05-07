using System;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Models.Query
{
    /// <summary>
    /// Defines a read-only view of an <see cref="Ingredient"/>.
    /// </summary>
    public class IngredientModel
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the recipe identifier.
        /// </summary>
        public Guid RecipeId { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        public string Amount { get; private set; }
        
        /// <summary>
        /// Gets the category of this ingredient.
        /// </summary>
        public IngredientCategoryModel Category { get; private set; }

        /// <summary>
        /// Creates an <see cref="IngredientModel"/> instance from the given <see cref="Ingredient"/>.
        /// </summary>
        /// <param name="ingredient">An ingredient.</param>
        /// <returns>A read-only view of the given ingredient.</returns>
        public static IngredientModel From(Ingredient ingredient)
        {
            return new IngredientModel()
            {
                Id = ingredient.Id,
                RecipeId = ingredient.RecipeId,
                Name = ingredient.Name,
                Amount = ingredient.Amount,
                Category = IngredientCategoryModel.From(ingredient.Category)
            };
        }
    }
}