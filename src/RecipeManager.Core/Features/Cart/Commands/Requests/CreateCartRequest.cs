using MediatR;
using RecipeManager.Core.Features.Cart.Models.Query;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Cart.Commands.Requests
{
    /// <summary>
    /// Represents a command request to create a new <see cref="Cart"/> for a given user.
    /// </summary>
    public class CreateCartRequest : IRequest<CartModel>
    {
        /// <summary>
        /// Gets or sets the user creating this cart.
        /// </summary>
        public User User { get; set; }
    }
}