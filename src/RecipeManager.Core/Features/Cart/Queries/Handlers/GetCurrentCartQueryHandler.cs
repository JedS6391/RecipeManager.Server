using System.Threading;
using System.Threading.Tasks;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Data.Extensions;
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
            var cart = await RecipeDomainContext.GetCurrentCart(request.User);

            return cart == null ? 
                throw new NoCurrentCartException($"No current cart exists [User ID = {request.User.Id}]") : 
                CartModel.From(cart);
        }
    }
}