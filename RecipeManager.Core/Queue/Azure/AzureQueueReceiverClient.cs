using System.Threading.Tasks;
using Newtonsoft.Json;
using RecipeManager.Core.Queue.Abstract;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Queue.Azure
{
    /// <summary>
    /// An implementation of <see cref="IQueueReceiverClient{TMessage}"/> that will
    /// receive messages from Azure queue storage.
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public class AzureQueueReceiverClient<TMessage>
        : BaseAzureQueueClient, IQueueReceiverClient<TMessage>
        where TMessage : Message
    {
        private readonly string _queueName;
        
        public AzureQueueReceiverClient(
            string queueName,
            IQueueConnectionDetailsProvider<AzureQueueConnectionDetails> connectionDetailsProvider)
            : base(connectionDetailsProvider)
        {
            _queueName = queueName;
        }
        
        public async Task<TMessage> GetNextMessageAsync()
        {
            var queue = await GetQueue(_queueName);

            var message = await queue.GetMessageAsync();

            if (message == null)
            {
                return null;
            }

            // TODO: How to handle message processing failure?
            await queue.DeleteMessageAsync(message);

            return JsonConvert.DeserializeObject<TMessage>(message.AsString);
        }
    }
}