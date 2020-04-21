using System.Collections.Generic;
using MediatR;
using RecipeManager.Core.Features.Cart.Models.Command;
using RecipeManager.Core.Features.Cart.Models.Query;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Cart.Commands.Requests
{
    /// <summary>
    /// Represents a command request to update the items in the current cart.
    /// </summary>
    public class UpdateCartItemsRequest : IRequest<CartModel>
    {
        /// <summary>
        /// Gets or sets the user whose cart the ingredients will be added to.
        /// </summary>
        public User User { get; set; }
        
        /// <summary>
        /// Gets or sets the updates to the cart items.
        /// </summary>
        public IEnumerable<CartItemUpdateModel> CartItemUpdates { get; set; }
    }
}