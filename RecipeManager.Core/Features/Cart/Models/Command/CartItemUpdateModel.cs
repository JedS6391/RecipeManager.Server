using System;

namespace RecipeManager.Core.Features.Cart.Models.Command
{
    /// <summary>
    /// Defines a model for a cart item update.
    /// </summary>
    public class CartItemUpdateModel
    {
        /// <summary>
        /// Gets or sets the identifier of the ingredient to add.
        /// </summary>
        public Guid IngredientId { get; set; }
    }
}