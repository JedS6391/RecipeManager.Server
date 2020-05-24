namespace RecipeManager.Core.Queue.Azure
{
    /// <summary>
    /// Represents the connection details for connecting to Azure queue storage.
    /// </summary>
    public class AzureQueueConnectionDetails
    {
        /// <summary>
        /// Gets or sets the storage account connection string.
        /// </summary>
        public string StorageConnectionString { get; set; }
    }
}