using System.Linq;
using System.Threading.Tasks;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Exceptions;
using RecipeManager.Core.Features.Cart.Commands.Requests;
using RecipeManager.Core.Features.Cart.Models.Query;
using RecipeManager.Core.Infrastructure.Abstract;

namespace RecipeManager.Core.Features.Cart.Commands.Validation
{
    /// <summary>
    /// A command request validator for <see cref="CreateCartRequest"/> requests.
    /// </summary>
    public class CreateCartCommandRequestValidator 
        : ICommandRequestValidator<CreateCartRequest, CartModel>
    {
        private IRecipeDomainContext _recipeDomainContext;

        public CreateCartCommandRequestValidator(IRecipeDomainContext recipeDomainContext)
        {
            _recipeDomainContext = recipeDomainContext;
        }
        
        public Task Validate(CreateCartRequest request)
        {
            if (_recipeDomainContext.Carts.Any(c => c.UserId == request.User.Id && c.IsCurrent))
            {
                ThrowValidationError(ValidationErrors.UserAlreadyHasACurrentCart);
            }
            
            return Task.CompletedTask;
        }
        
        private void ThrowValidationError(params string[] validationErrors)
        {
            throw new ValidationException("Unable to create cart due to failed validations.", validationErrors);
        }

        private static class ValidationErrors
        {
            public static string UserAlreadyHasACurrentCart = $"{nameof(CreateCartRequest)}:current-cart-already-exists";
        }
    }
}