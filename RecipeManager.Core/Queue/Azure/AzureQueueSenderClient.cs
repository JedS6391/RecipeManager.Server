using System.Threading.Tasks;
using Microsoft.Azure.Storage.Queue;
using Newtonsoft.Json;
using RecipeManager.Core.Queue.Abstract;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Queue.Azure
{
    public class AzureQueueSenderClient<TMessage>
        : BaseAzureQueueClient, IQueueSenderClient<TMessage>
        where TMessage : Message
    {
        private readonly string _queueName;
        
        public AzureQueueSenderClient(
            string queueName,
            IQueueConnectionDetailsProvider<AzureQueueConnectionDetails> connectionDetailsProvider)
            : base(connectionDetailsProvider)
        {
            _queueName = queueName;
        }
        
        public async Task SendMessageAsync(TMessage message)
        {
            var queue = await GetQueue(_queueName);

            var messageJson = JsonConvert.SerializeObject(message);
            var queueMessage = new CloudQueueMessage(messageJson);

            await queue.AddMessageAsync(queueMessage);
        }
    }
}