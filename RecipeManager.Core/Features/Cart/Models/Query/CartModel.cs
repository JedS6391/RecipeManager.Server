using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeManager.Core.Features.Cart.Models.Query
{
    /// <summary>
    /// Defines a read-only view of a <see cref="Cart"/>.
    /// </summary>
    public class CartModel
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; private set; }
        
        /// <summary>
        /// Gets or sets the user identifier of this cart.
        /// </summary>
        public string UserId { get; private set; }
        
        /// <summary>
        /// Gets or sets the date and time this cart was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether this is the current cart.
        /// </summary>
        public bool IsCurrent { get; private set; }
        
        /// <summary>
        /// Gets or sets the <see cref="Domain.Entities.CartItem"/> in the cart.
        /// </summary>
        public ICollection<CartItemModel> Items { get; set; }

        public static CartModel From(Domain.Entities.Cart cart)
        {
            return new CartModel()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                CreatedAt = cart.CreatedAt,
                IsCurrent = cart.IsCurrent,
                Items = cart.Items?.Select(CartItemModel.From).ToList()
            };
        }
    }
}