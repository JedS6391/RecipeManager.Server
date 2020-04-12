using System;

namespace RecipeManager.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public string EntityType { get; private set; }

        public NotFoundException(string message, string entityType)
            : base(message)
        {
            EntityType = entityType;
        }
    }
}
