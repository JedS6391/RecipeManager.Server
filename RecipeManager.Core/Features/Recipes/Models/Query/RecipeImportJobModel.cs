using System;
using RecipeManager.Domain.Entities;
using RecipeManager.Domain.Entities.Enum;

namespace RecipeManager.Core.Features.Recipes.Models.Query
{
    /// <summary>
    /// Defines a read-only view of a <see cref="RecipeImportJobM"/>.
    /// </summary>
    public class RecipeImportJobModel
    {
        /// <summary>
        /// Gets the identifier
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the status of the import job.
        /// </summary>
        public RecipeImportJobStatus Status { get; private set; }
        
        /// <summary>
        /// Gets a <see cref="RecipeModel"/> for the recipe that was imported as a result of the job.
        /// </summary>
        /// <remarks>
        /// Note that this will only have a value when the status is <see cref="RecipeImportJobStatus.Completed"/>.
        /// </remarks>
        public RecipeModel ImportedRecipe { get; private set; }

        /// <summary>
        /// Creates a <see cref="RecipeImportJobModel"/> instance from the given <see cref="RecipeImportJob"/>.
        /// </summary>
        /// <param name="job">A recipe import job.</param>
        /// <returns>A read-only view of the given recipe import job.</returns>
        public static RecipeImportJobModel From(RecipeImportJob job)
        {
            return new RecipeImportJobModel()
            {
                Id = job.Id,
                Status = job.Status,
                ImportedRecipe = RecipeModel.From(job.ImportedRecipe)
            };
        }
    }
}