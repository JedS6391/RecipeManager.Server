using System;

namespace RecipeManager.Core.Exceptions
{
    /// <summary>
    /// An exception for when an entity can not be found.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Gets the type of entity that could not be found.
        /// </summary>
        public string EntityType { get; private set; }

        public NotFoundException(string message, string entityType)
            : base(message)
        {
            EntityType = entityType;
        }
    }
}
