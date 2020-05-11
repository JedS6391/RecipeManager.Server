using System;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using RecipeManager.Core.Queue.Abstract;

namespace RecipeManager.Core.Queue.Azure
{
    public abstract class BaseAzureQueueClient
    {
        private readonly IQueueConnectionDetailsProvider<AzureQueueConnectionDetails> _connectionDetailsProvider;

        protected BaseAzureQueueClient(
            IQueueConnectionDetailsProvider<AzureQueueConnectionDetails> connectionDetailsProvider)
        {
            _connectionDetailsProvider = connectionDetailsProvider;
        }

        protected async Task<CloudQueue> GetQueue(string queueName)
        {
            var storageAccount = GetStorageAccount();
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);

            await queue.CreateIfNotExistsAsync();

            return queue;
        }
        
        protected CloudStorageAccount GetStorageAccount()
        {
            var connectionDetails = _connectionDetailsProvider.GetConnectionDetails();
            
            if (!CloudStorageAccount.TryParse(connectionDetails.StorageConnectionString, out var storageAccount))
            {
                // TODO
                throw new Exception("Unable to parse storage account connection string");
            }

            return storageAccount;
        }
    }
}