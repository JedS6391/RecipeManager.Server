using System;

namespace RecipeManager.Core.Features.Cart.Models.Command
{
    /// <summary>
    /// Defines a model for adding an ingredient to a cart.
    /// </summary>
    public class AddIngredientToCartModel
    {
        /// <summary>
        /// Gets or sets the identifier of the ingredient to add.
        /// </summary>
        public Guid IngredientId { get; set; }
    }
}