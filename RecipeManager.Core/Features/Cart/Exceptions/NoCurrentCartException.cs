using RecipeManager.Core.Exceptions;

namespace RecipeManager.Core.Features.Cart.Exceptions
{
    public class NoCurrentCartException : NotFoundException
    {
        public NoCurrentCartException(string message) 
            : base(message, nameof(Domain.Entities.Cart))
        {}
    }
}