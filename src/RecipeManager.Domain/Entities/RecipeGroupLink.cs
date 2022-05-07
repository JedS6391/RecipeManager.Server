using System;

namespace RecipeManager.Domain.Entities
{
    /// <summary>
    /// Represents the link between a <see cref="Recipe"/> and a <see cref="RecipeGroup"/>.
    /// </summary>
    public class RecipeGroupLink
    {
        /// <summary>
        /// Gets the identifier of the <see cref="RecipeGroup"/>.
        /// </summary>
        public Guid RecipeGroupId { get; set; }
        
        /// <summary>
        /// Gets the identifier of the <see cref="Recipe"/>.
        /// </summary>
        public Guid RecipeId { get; set; }
        
        /// <summary>
        /// Gets the <see cref="RecipeGroup"/>.
        /// </summary>
        public RecipeGroup RecipeGroup { get; set; }
        
        /// <summary>
        /// Gets the <see cref="Recipe"/>.
        /// </summary>
        public Recipe Recipe { get; set; }
    }
}