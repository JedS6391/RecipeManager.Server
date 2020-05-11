using RecipeManager.Core.Queue.Abstract;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Queue.Azure
{
    /// <summary>
    /// An implementation of <see cref="IQueueClientFactory{TMessage}"/> that will provide queue clients backed by Azure queue storage.
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public class AzureQueueClientFactory<TMessage>
        : IQueueClientFactory<TMessage>
        where TMessage : Message
    {
        private readonly IQueueConnectionDetailsProvider<AzureQueueConnectionDetails> _connectionDetailsProvider;

        public AzureQueueClientFactory(IQueueConnectionDetailsProvider<AzureQueueConnectionDetails> connectionDetailsProvider)
        {
            _connectionDetailsProvider = connectionDetailsProvider;
        }
        
        public IQueueSenderClient<TMessage> GetSenderClient(string queueName)
        {
            return new AzureQueueSenderClient<TMessage>(queueName, _connectionDetailsProvider);
        }

        public IQueueReceiverClient<TMessage> GetReceiverClient(string queueName)
        {
            return new AzureQueueReceiverClient<TMessage>(queueName, _connectionDetailsProvider);
        }
    }
}