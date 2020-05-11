using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Queue.Abstract
{
    public interface IQueueReceiverClient<TMessage>
        where TMessage : Message
    {
        Task<TMessage> GetNextMessageAsync();
    }
}