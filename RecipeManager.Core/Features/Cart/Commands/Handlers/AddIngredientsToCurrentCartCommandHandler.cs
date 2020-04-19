using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Cart.Commands.Requests;
using RecipeManager.Core.Features.Cart.Exceptions;
using RecipeManager.Core.Features.Cart.Models.Query;
using RecipeManager.Core.Infrastructure.Abstract;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Cart.Commands.Handlers
{
    /// <summary>
    /// Handles all <see cref="AddIngredientsToCurrentCartRequest"/> requests.
    /// </summary>
    public class AddIngredientsToCurrentCartCommandHandler 
        : BaseValidatingCommandHandler<AddIngredientsToCurrentCartRequest, CartModel>
    {
        public AddIngredientsToCurrentCartCommandHandler(
            IRecipeDomainContext recipeDomainContext, 
            IEnumerable<ICommandRequestValidator<AddIngredientsToCurrentCartRequest, CartModel>> commandRequestValidators) 
            : base(recipeDomainContext, commandRequestValidators)
        {}

        public override async Task<CartModel> DoHandleRequest(AddIngredientsToCurrentCartRequest request, CancellationToken cancellationToken)
        {
            var currentCart = await RecipeDomainContext
                .Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Ingredient)
                .FirstOrDefaultAsync(c => c.UserId == request.User.Id && c.IsCurrent);

            if (currentCart == null)
            {
                throw new NoCurrentCartException($"No current cart exists [User ID = {request.User.Id}");
            }

            var cartItems = request.Ingredients.Select(i => new CartItem()
            {
                CartId = currentCart.Id,
                CreatedAt = DateTime.UtcNow,
                IngredientId = i.IngredientId
            });

            currentCart.Items = cartItems.ToList();

            await RecipeDomainContext.SaveChangesAsync();

            return CartModel.From(currentCart);
        }
    }
}