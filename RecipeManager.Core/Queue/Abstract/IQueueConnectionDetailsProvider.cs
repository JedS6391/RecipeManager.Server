namespace RecipeManager.Core.Queue.Abstract
{
    /// <summary>
    /// Defines a provider for queue connection details.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueueConnectionDetailsProvider<T>
    {
        /// <summary>
        /// Gets the connection details.
        /// </summary>
        T ConnectionDetails { get; }
    }
}