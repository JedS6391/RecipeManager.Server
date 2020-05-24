using RecipeManager.Core.Exceptions;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Exceptions
{
    /// <summary>
    /// An exception for when a <see cref="RecipeImportJob"/> can not be found.
    /// </summary>
    public class RecipeImportJobNotFoundException : NotFoundException
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RecipeImportJobNotFoundException"/> class.
        /// </summary>
        /// <param name="message"></param>
        public RecipeImportJobNotFoundException(string message)
            : base(message, nameof(RecipeImportJob))
        {}
    }
}