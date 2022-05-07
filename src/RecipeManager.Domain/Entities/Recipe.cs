using System;
using System.Collections.Generic;
using System.Linq;
using RecipeManager.Domain.Entities.Abstract;

namespace RecipeManager.Domain.Entities
{
    /// <summary>
    /// Represents a recipe.
    /// </summary>
    /// <remarks>A recipe is composed of a collection of ingredients and instructions.</remarks>
    public class Recipe : IIdentifiable<Guid>, IUserIdentifiable
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
        
        /// <summary>
        /// Gets the recipe group links.
        /// </summary>
        public ICollection<RecipeGroupLink> RecipeGroupLinks { get; set; }

        /// <summary>
        /// Gets the recipe groups.
        /// </summary>
        public IEnumerable<RecipeGroup> RecipeGroups => RecipeGroupLinks.Select(rgl => rgl.RecipeGroup);

        /// <summary>
        /// Gets or sets the identifier of the user this recipe belongs to.
        /// </summary>
        public string UserId { get; set; }
    }
}
