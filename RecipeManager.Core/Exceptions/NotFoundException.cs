using System;
namespace RecipeManager.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public string EntityType { get; set; }

        public NotFoundException(string message)
            : base(message)
        {}
    }
}
