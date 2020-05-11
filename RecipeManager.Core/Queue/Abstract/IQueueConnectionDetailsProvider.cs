namespace RecipeManager.Core.Queue.Abstract
{
    public interface IQueueConnectionDetailsProvider<T>
    {
        T GetConnectionDetails();
    }
}