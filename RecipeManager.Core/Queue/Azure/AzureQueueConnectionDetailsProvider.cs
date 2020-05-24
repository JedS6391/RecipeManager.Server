using RecipeManager.Core.Queue.Abstract;

namespace RecipeManager.Core.Queue.Azure
{
    /// <summary>
    /// An implementation of <see cref="IQueueConnectionDetailsProvider{T}"/> that provides
    /// connection details for connecting to Azure queue storage.
    /// </summary>
    public class AzureQueueConnectionDetailsProvider
        : IQueueConnectionDetailsProvider<AzureQueueConnectionDetails>
    {
        public AzureQueueConnectionDetailsProvider(AzureQueueConnectionDetails connectionDetails)
        {
            ConnectionDetails = connectionDetails;
        }

        public AzureQueueConnectionDetails ConnectionDetails { get; }
    }
}