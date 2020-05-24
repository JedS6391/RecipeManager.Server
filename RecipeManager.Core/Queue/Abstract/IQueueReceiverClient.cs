using System.Threading.Tasks;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Queue.Abstract
{
    /// <summary>
    /// Defines a client for operations relating to receiving from a queue. 
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public interface IQueueReceiverClient<TMessage>
        where TMessage : Message
    {
        /// <summary>
        /// Gets the next message from the queue.
        /// </summary>
        /// <returns></returns>
        Task<TMessage> GetNextMessageAsync();
    }
}