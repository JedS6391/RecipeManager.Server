using System;
using System.Collections.Generic;
using System.Linq;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Models
{
    /// <summary>
    /// Defines a read-only view of a <see cref="Recipe"/>.
    /// </summary>
    public class RecipeModel
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the ingredients.
        /// </summary>
        public ICollection<IngredientModel> Ingredients { get; private set; }

        /// <summary>
        /// Gets the instructions.
        /// </summary>
        public ICollection<InstructionModel> Instructions { get; private set; }

        /// <summary>
        /// Creates a <see cref="RecipeModel"/> instance from the given <see cref="Recipe"/>.
        /// </summary>
        /// <param name="recipe">A recipe.</param>
        /// <returns>A read-only view of the given recipe.</returns>
        public static RecipeModel From(Recipe recipe)
        {
            return new RecipeModel()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Ingredients = recipe.Ingredients.Select(IngredientModel.From).ToList(),
                Instructions = recipe.Instructions.Select(InstructionModel.From).ToList()
            };
        }
    }
}