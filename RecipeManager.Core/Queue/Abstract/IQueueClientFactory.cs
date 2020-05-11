using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Queue.Abstract
{
    /// <summary>
    /// Defines a factory for providing queue client instances.
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public interface IQueueClientFactory<TMessage>
        where TMessage : Message
    {
        /// <summary>
        /// Gets a <see cref="IQueueSenderClient{TMessage}"/> instance.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        IQueueSenderClient<TMessage> GetSenderClient(string queueName);
        
        /// <summary>
        /// Gets a <see cref="IQueueReceiverClient{TMessage}"/> instance.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        IQueueReceiverClient<TMessage> GetReceiverClient(string queueName);
    }
}