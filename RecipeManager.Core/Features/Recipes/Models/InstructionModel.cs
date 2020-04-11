using System;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Models
{
    /// <summary>
    /// Defines a read-only view of an <see cref="Instruction"/>.
    /// </summary>
    public class InstructionModel
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
        /// Gets the sequence.
        /// </summary>
        public int Sequence { get; private set; }

        /// <summary>
        /// Gets the details.
        /// </summary>
        public string Details { get; private set; }

        /// <summary>
        /// Creates an <see cref="InstructionModel"/> instance from the given <see cref="Instruction"/>.
        /// </summary>
        /// <param name="instruction">An instruction.</param>
        /// <returns>A read-only view of the given instruction.</returns>
        public static InstructionModel From(Instruction instruction)
        {
            return new InstructionModel()
            {
                Id = instruction.Id,
                RecipeId = instruction.RecipeId,
                Sequence = instruction.Sequence,
                Details = instruction.Details
            };
        }
    }
}