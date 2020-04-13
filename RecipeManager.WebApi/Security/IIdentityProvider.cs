using RecipeManager.Domain.Entities;

namespace RecipeManager.WebApi.Security
{
    /// <summary>
    /// Defines a provider for the current user for a given context.
    /// </summary>
    public interface IIdentityProvider
    {
        /// <summary>
        /// Gets the current user.
        /// </summary>
        User Current { get; }
    }
}
