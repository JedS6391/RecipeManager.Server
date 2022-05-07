namespace RecipeManager.Domain.Entities.Abstract
{
    /// <summary>
    /// Defines an entity that is associated to a <see cref="User"/>.
    /// </summary>
    public interface IUserIdentifiable
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        string UserId { get; }
    }
}