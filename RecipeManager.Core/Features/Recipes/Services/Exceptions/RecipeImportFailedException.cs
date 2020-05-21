using System;

namespace RecipeManager.Core.Features.Recipes.Services.Exceptions
{
    /// <summary>
    /// An exception given when the import of a recipe via <see cref="RecipeImporterService"/> fails.
    /// </summary>
    public class RecipeImportFailedException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RecipeImportFailedException"/> class.
        /// </summary>
        /// <param name="message"></param>
        public RecipeImportFailedException(string message) 
            : base(message)
        {}
    }
}