using System;
using System.Collections.Generic;
using System.Linq;
using RecipeManager.Domain.Entities.Abstract;

namespace RecipeManager.Domain.Entities
{
    /// <summary>
    /// Represents a recipe group.
    /// </summary>
    public class RecipeGroup : IIdentifiable<Guid>, IUserIdentifiable
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Gets the identifier of the user this recipe group belongs to.
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// Gets the name of the recipe group.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets the recipe group links.
        /// </summary>
        public ICollection<RecipeGroupLink> RecipeGroupLinks { get; set; }

        /// <summary>
        /// Gets the recipes.
        /// </summary>
        public IEnumerable<Recipe> Recipes => RecipeGroupLinks.Select(rgl => rgl.Recipe);
    }
}