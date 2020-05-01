using System;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Models.Query
{
    public class RecipeGroupModel
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
        /// Creates a <see cref="RecipeGroupModel"/> instance from the given <see cref="RecipeGroup"/>.
        /// </summary>
        /// <param name="recipeGroup">A recipe group.</param>
        /// <returns>A read-only view of the given recipe group.</returns>
        public static RecipeGroupModel From(RecipeGroup recipeGroup)
        {
            return new RecipeGroupModel()
            {
                Id = recipeGroup.Id,
                Name = recipeGroup.Name
            };
        }
    }
}