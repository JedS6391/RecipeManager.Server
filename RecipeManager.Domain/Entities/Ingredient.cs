using System;
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
        /// Gets or sets the recipe that this ingredient is for.
        /// </summary>
        public Recipe Recipe { get; set; }
    }
}
