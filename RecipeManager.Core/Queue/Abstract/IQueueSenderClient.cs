using System.Threading.Tasks;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Queue.Abstract
{
    /// <summary>
    /// Defines a client for operations relating to sending to a queue. 
    /// </summary>
    public interface IQueueSenderClient<TMessage>
        where TMessage : Message
    {
        /// <summary>
        /// Sends a message to the queue.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendMessageAsync(TMessage message);
    }
}