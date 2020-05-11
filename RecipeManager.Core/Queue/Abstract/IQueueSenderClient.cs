using System.Threading.Tasks;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Queue.Abstract
{
    public interface IQueueSenderClient<TMessage>
        where TMessage : Message
    {
        Task SendMessageAsync(TMessage message);
    }
}