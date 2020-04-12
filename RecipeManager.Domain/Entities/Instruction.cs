using System;
using RecipeManager.Domain.Entities.Abstract;

namespace RecipeManager.Domain.Entities
{
    /// <summary>
    /// Represents an instruction of a <see cref="Entities.Recipe"/>.
    /// </summary>
    public class Instruction : IIdentifiable<Guid>
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
        /// Gets or sets the sequence.
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the recipe that this instruction is for.
        /// </summary>
        public Recipe Recipe { get; set; }
    }
}
