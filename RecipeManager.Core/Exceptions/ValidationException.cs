using System;

namespace RecipeManager.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public string[] ValidationErrors { get; private set; }

        public ValidationException(string message, string[] validationErrors)
            : base(message)
        {
            ValidationErrors = validationErrors;
        }
    }
}
