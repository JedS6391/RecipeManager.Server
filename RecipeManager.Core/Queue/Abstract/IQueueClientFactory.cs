using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Queue.Abstract
{
    public interface IQueueClientFactory<TMessage>
        where TMessage : Message
    {
        IQueueSenderClient<TMessage> GetSenderClient(string queueName);
        IQueueReceiverClient<TMessage> GetReceiverClient(string queueName);
    }
}