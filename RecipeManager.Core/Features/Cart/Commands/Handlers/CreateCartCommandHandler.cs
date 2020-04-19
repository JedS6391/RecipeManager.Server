using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Cart.Commands.Requests;
using RecipeManager.Core.Features.Cart.Models.Query;
using RecipeManager.Core.Infrastructure.Abstract;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Cart.Commands.Handlers
{
    /// <summary>
    /// Handles all <see cref="CreateCartRequest"/> requests.
    /// </summary>
    public class CreateCartCommandHandler : BaseValidatingCommandHandler<CreateCartRequest, CartModel>
    {
        public CreateCartCommandHandler(
            IRecipeDomainContext recipeDomainContext, 
            IEnumerable<ICommandRequestValidator<CreateCartRequest, CartModel>> commandRequestValidators) 
            : base(recipeDomainContext, commandRequestValidators)
        {}

        public override async Task<CartModel> DoHandleRequest(CreateCartRequest request, CancellationToken cancellationToken)
        {
            var cart = new Domain.Entities.Cart()
            {
                UserId = request.User.Id,
                CreatedAt = DateTime.UtcNow,
                IsCurrent = true,
                Items = new CartItem[] { }
            };

            await RecipeDomainContext.Carts.AddAsync(cart);

            await RecipeDomainContext.SaveChangesAsync();

            return CartModel.From(cart);
        }
    }
}