using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Queue.Abstract
{
    /// <summary>
    /// Defines a provider for queue names.
    /// </summary>
    public interface IQueueNameProvider
    {
        /// <summary>
        /// Gets the queue name for the specified message type.
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <returns></returns>
        string GetQueueNameForMessageType<TMessage>() where TMessage : Message;
    }
}