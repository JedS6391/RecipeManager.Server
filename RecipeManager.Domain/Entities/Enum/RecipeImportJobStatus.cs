namespace RecipeManager.Domain.Entities.Enum
{
    /// <summary>
    /// Defines the status of a <see cref="RecipeImportJob"/>.
    /// </summary>
    public enum RecipeImportJobStatus
    {
        /// <summary>
        /// The job has been created.
        /// </summary>
        Created,
        
        /// <summary>
        /// The job has been queued for processing.
        /// </summary>
        Queued,
        
        /// <summary>
        /// The job has been removed from the queue and started processing.
        /// </summary>
        Started,
        
        /// <summary>
        /// The job has failed processing.
        /// </summary>
        Failed,
        
        /// <summary>
        /// The job has completed processing.
        /// </summary>
        Completed
    }
}