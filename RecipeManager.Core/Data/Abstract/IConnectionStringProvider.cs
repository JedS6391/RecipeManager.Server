namespace RecipeManager.Core.Data.Abstract
{
    /// <summary>
    /// Defines a provider for database connection strings.
    /// </summary>
    public interface IConnectionStringProvider
    {
        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        string ConnectionString { get; }
    }
}
