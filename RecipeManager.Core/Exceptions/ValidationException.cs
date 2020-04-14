using System;

namespace RecipeManager.Core.Exceptions
{
    /// <summary>
    /// An exception for when validation has failed.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        public string[] ValidationErrors { get; private set; }

        public ValidationException(string message, string[] validationErrors)
            : base(message)
        {
            ValidationErrors = validationErrors;
        }
    }
}
