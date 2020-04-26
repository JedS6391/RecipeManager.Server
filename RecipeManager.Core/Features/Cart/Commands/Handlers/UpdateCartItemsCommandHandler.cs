using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Data.Extensions;
using RecipeManager.Core.Features.Cart.Commands.Requests;
using RecipeManager.Core.Features.Cart.Exceptions;
using RecipeManager.Core.Features.Cart.Models.Query;
using RecipeManager.Core.Infrastructure.Abstract;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Cart.Commands.Handlers
{
    /// <summary>
    /// Handles all <see cref="UpdateCartItemsRequest"/> requests.
    /// </summary>
    public class UpdateCartItemsCommandHandler 
        : BaseValidatingCommandHandler<UpdateCartItemsRequest, CartModel>
    {
        public UpdateCartItemsCommandHandler(
            IRecipeDomainContext recipeDomainContext, 
            IEnumerable<ICommandRequestValidator<UpdateCartItemsRequest, CartModel>> commandRequestValidators) 
            : base(recipeDomainContext, commandRequestValidators)
        {}

        public override async Task<CartModel> DoHandleRequest(UpdateCartItemsRequest request, CancellationToken cancellationToken)
        {
            var currentCart = await RecipeDomainContext.GetCurrentCart(request.User);

            if (currentCart == null)
            {
                throw new NoCurrentCartException($"No current cart exists [User ID = {request.User.Id}");
            }

            var cartItems = request.CartItemUpdates.Select(i => new CartItem()
            {
                CartId = currentCart.Id,
                CreatedAt = DateTime.UtcNow,
                IngredientId = i.IngredientId
            });

            currentCart.Items = cartItems.ToList();

            await RecipeDomainContext.SaveChangesAsync();
            
            // Refresh the current cart entity
            currentCart = await RecipeDomainContext
                .Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Ingredient)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(c => c.UserId == request.User.Id && c.IsCurrent);
            
            return CartModel.From(currentCart);
        }
    }
}