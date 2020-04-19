using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Cart.Exceptions;
using RecipeManager.Core.Features.Cart.Models.Query;
using RecipeManager.Core.Features.Cart.Queries.Requests;
using RecipeManager.Core.Infrastructure.Abstract;

namespace RecipeManager.Core.Features.Cart.Queries.Handlers
{
    /// <summary>
    /// Handles <see cref="GetCurrentCartQuery"/> requests.
    /// </summary>
    public class GetCurrentCartQueryHandler : BaseQueryHandler<GetCurrentCartQuery, CartModel>
    {
        public GetCurrentCartQueryHandler(IRecipeDomainContext recipeDomainContext) 
            : base(recipeDomainContext)
        {}

        /// <inheritdoc/>
        public override async Task<CartModel> Handle(GetCurrentCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await RecipeDomainContext
                .Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Ingredient)
                .FirstOrDefaultAsync(c => c.UserId == request.User.Id && c.IsCurrent);

            return cart == null ? 
                throw new NoCurrentCartException($"No current cart exists [User ID = {request.User.Id}]") : 
                CartModel.From(cart);
        }
    }
}