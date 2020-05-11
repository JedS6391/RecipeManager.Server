using System;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using RecipeManager.Core.Queue.Abstract;

namespace RecipeManager.Core.Queue.Azure
{
    /// <summary>
    /// Provides a set of base functionality for Azure queue storage clients.
    /// </summary>
    public abstract class BaseAzureQueueClient
    {
        private readonly IQueueConnectionDetailsProvider<AzureQueueConnectionDetails> _connectionDetailsProvider;

        protected BaseAzureQueueClient(
            IQueueConnectionDetailsProvider<AzureQueueConnectionDetails> connectionDetailsProvider)
        {
            _connectionDetailsProvider = connectionDetailsProvider;
        }

        /// <summary>
        /// Gets the queue with the specified name.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        protected async Task<CloudQueue> GetQueue(string queueName)
        {
            var storageAccount = GetStorageAccount();
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);

            await queue.CreateIfNotExistsAsync();

            return queue;
        }
        
        /// <summary>
        /// Gets the cloud storage account.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected CloudStorageAccount GetStorageAccount()
        {
            var connectionDetails = _connectionDetailsProvider.ConnectionDetails;
            
            if (!CloudStorageAccount.TryParse(connectionDetails.StorageConnectionString, out var storageAccount))
            {
                // TODO
                throw new Exception("Unable to parse storage account connection string");
            }

            return storageAccount;
        }
    }
}