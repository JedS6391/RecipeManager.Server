namespace RecipeManager.Domain.Entities.Abstract
{
    /// <summary>
    /// Defines an identifiable entity.
    /// </summary>
    /// <typeparam name="TId">The type of identifier.</typeparam>
    public interface IIdentifiable<TId>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        TId Id { get; }
    }
}
