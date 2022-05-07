using MediatR;
using RecipeManager.Core.Features.Cart.Models.Query;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Cart.Queries.Requests
{
    /// <summary>
    /// Represents a query request for the current <see cref="Cart"/> for the specified user.
    /// </summary>
    public class GetCurrentCartQuery : IRequest<CartModel>
    {
        /// <summary>
        /// Gets or sets the user whose cart will be retrieved.
        /// </summary>
        public User User { get; set; }
    }
}