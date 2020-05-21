using RecipeManager.Core.Exceptions;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Exceptions
{
    /// <summary>
    /// An exception for when a <see cref="Recipe"/> can not be found.
    /// </summary>
    public class RecipeNotFoundException : NotFoundException
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RecipeNotFoundException"/> class.
        /// </summary>
        /// <param name="message"></param>
        public RecipeNotFoundException(string message)
            : base(message, nameof(Recipe))
        {}
    }
}
