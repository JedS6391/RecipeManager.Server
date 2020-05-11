using RecipeManager.Core.Queue.Abstract;

namespace RecipeManager.Core.Queue.Azure
{
    public class AzureQueueConnectionDetailsProvider
        : IQueueConnectionDetailsProvider<AzureQueueConnectionDetails>
    {
        private readonly AzureQueueConnectionDetails _connectionDetails;
        
        public AzureQueueConnectionDetailsProvider(AzureQueueConnectionDetails connectionDetails)
        {
            _connectionDetails = connectionDetails;
        }
        
        public AzureQueueConnectionDetails GetConnectionDetails()
        {
            return _connectionDetails;
        }
    }
}