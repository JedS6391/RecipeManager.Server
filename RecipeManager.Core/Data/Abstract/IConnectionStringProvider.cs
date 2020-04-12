namespace RecipeManager.Core.Infrastructure.Abstract
{
    /// <summary>
    /// Defines a provider for database connection strings.
    /// </summary>
    public interface IConnectionStringProvider
    {
        /// <summary>
        /// Gets a database connection string.
        /// </summary>
        /// <returns></returns>
        string GetConnectionString();
    }
}
