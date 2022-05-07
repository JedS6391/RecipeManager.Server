using System;
using RecipeManager.Domain.Entities.Abstract;

namespace RecipeManager.Domain.Entities
{
    /// <summary>
    /// Represents a user of the system.
    /// </summary>
    public class User : IIdentifiable<string>
    {
        /// <summary>
        /// Gets the identifier of the user.
        /// </summary>
        public string Id { get; private set; }

        public User(string id)
        {
            Id = id;
        }
    }
}
