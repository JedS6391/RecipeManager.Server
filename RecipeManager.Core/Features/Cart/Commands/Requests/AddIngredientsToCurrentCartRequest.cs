using System.Collections.Generic;
using MediatR;
using RecipeManager.Core.Features.Cart.Models.Command;
using RecipeManager.Core.Features.Cart.Models.Query;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Cart.Commands.Requests
{
    /// <summary>
    /// Represents a command request to add the given ingredients to the specified users current cart.
    /// </summary>
    public class AddIngredientsToCurrentCartRequest : IRequest<CartModel>
    {
        /// <summary>
        /// Gets or sets the user whose cart the ingredients will be added to.
        /// </summary>
        public User User { get; set; }
        
        /// <summary>
        /// Gets or sets the ingredients to add to the current cart.
        /// </summary>
        public IEnumerable<AddIngredientToCartModel> Ingredients { get; set; }
    }
}