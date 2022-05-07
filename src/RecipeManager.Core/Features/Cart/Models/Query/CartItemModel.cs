using System;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Cart.Models.Query
{
    /// <summary>
    /// Defines a read-only view of a <see cref="CartItem"/>.
    /// </summary>
    public class CartItemModel
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets or sets the identifier of the cart this item belongs to.
        /// </summary>
        public Guid CartId { get; private set; }

        /// <summary>
        /// Gets or sets the date and time the item was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="Ingredient"/> this item refers to.
        /// </summary>
        public IngredientModel Ingredient { get; private set; }

        public static CartItemModel From(CartItem cartItem)
        {
            return new CartItemModel()
            {
                Id = cartItem.Id,
                CartId = cartItem.CartId,
                CreatedAt = cartItem.CreatedAt,
                Ingredient = IngredientModel.From(cartItem.Ingredient)
            };
        }
    }
}