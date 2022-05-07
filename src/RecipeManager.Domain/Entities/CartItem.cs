using System;
using RecipeManager.Domain.Entities.Abstract;

namespace RecipeManager.Domain.Entities
{
    /// <summary>
    /// Represents an item in a cart.
    /// </summary>
    public class CartItem : IIdentifiable<Guid>
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; private set; }
        
        /// <summary>
        /// Gets or sets the identifier of the cart this item belongs to.
        /// </summary>
        public Guid CartId { get; set; }
        
        /// <summary>
        /// Gets or sets the date and time the item was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Gets or sets the identifier of the ingredient this cart item represents.
        /// </summary>
        public Guid IngredientId { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="Cart"/> this item belongs to.
        /// </summary>
        public Cart Cart { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="Ingredient"/> this item refers to.
        /// </summary>
        public Ingredient Ingredient { get; set; }
    }
}