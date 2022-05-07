using System;
using System.Collections.Generic;
using RecipeManager.Domain.Entities.Abstract;

namespace RecipeManager.Domain.Entities
{
    /// <summary>
    /// Represents a cart for a user.
    /// </summary>
    /// <remarks>A cart is composed of a collection of cart items. A user could have multiple carts.</remarks>
    public class Cart : IIdentifiable<Guid>, IUserIdentifiable
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; private set; }
        
        /// <summary>
        /// Gets or sets the user identifier of this cart.
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// Gets or sets the date and time this cart was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether this is the current cart.
        /// </summary>
        public bool IsCurrent { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="CartItem"/> in the cart.
        /// </summary>
        public ICollection<CartItem> Items { get; set; }
    }
}