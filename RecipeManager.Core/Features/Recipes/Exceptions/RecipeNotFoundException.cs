using RecipeManager.Core.Exceptions;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Exceptions
{
    public class RecipeNotFoundException : NotFoundException
    {
        public RecipeNotFoundException(string message)
            : base(message, nameof(Recipe))
        {}
    }
}
