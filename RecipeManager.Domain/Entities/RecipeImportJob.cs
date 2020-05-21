using System;
using RecipeManager.Domain.Entities.Abstract;
using RecipeManager.Domain.Entities.Enum;

namespace RecipeManager.Domain.Entities
{
    /// <summary>
    /// Represents a job to import a <see cref="Recipe"/>.
    /// </summary>
    public class RecipeImportJob : IIdentifiable<Guid>, IUserIdentifiable
    {
        /// <summary>
        /// Gets the identifier
        /// </summary>
        public Guid Id { get; private set; }
        
        /// <summary>
        /// Gets the identifier of the user that created this import job.
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// Gets the status of the import job.
        /// </summary>
        public RecipeImportJobStatus Status { get; set; }
        
        /// <summary>
        /// Gets or sets the identifier of the recipe that was import as a result of the job.
        /// </summary>
        public Guid? ImportedRecipeId { get; set; }
        
        /// <summary>
        /// Gets or sets the recipe that was imported as a result of the job.
        /// </summary>
        public Recipe ImportedRecipe { get; set; }
    }
}