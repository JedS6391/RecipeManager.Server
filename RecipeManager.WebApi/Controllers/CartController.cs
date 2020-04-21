using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManager.Core.Features.Cart.Commands.Requests;
using RecipeManager.Core.Features.Cart.Exceptions;
using RecipeManager.Core.Features.Cart.Models.Command;
using RecipeManager.Core.Features.Cart.Models.Query;
using RecipeManager.Core.Features.Cart.Queries.Requests;
using RecipeManager.WebApi.Security;

namespace RecipeManager.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/me/cart")]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IIdentityProvider _identityProvider;

        public CartController(
            IMediator mediator,
            IIdentityProvider identityProvider)
        {
            _mediator = mediator;
            _identityProvider = identityProvider;
        }
        
        /// <summary>
        /// Gets the current cart for the current user. If there is no current cart, one will be created.
        /// </summary>
        [HttpGet]
        [Route("current")]
        [AuthorizationScope(AuthorizationScopes.Cart.Read, AuthorizationScopes.Cart.Write)]
        [ProducesResponseType(typeof(CartModel), StatusCodes.Status200OK)]
        public async Task<CartModel> GetById(Guid recipeId)
        {
            try
            {
                return await _mediator.Send(new GetCurrentCartQuery()
                {
                    User = _identityProvider.Current
                });
            }
            catch (NoCurrentCartException)
            {
               // No current - need to create on
               return await _mediator.Send(new CreateCartRequest()
               {
                   User = _identityProvider.Current
               });
            }
        }

        [HttpPut]
        [Route("current/items")]
        [AuthorizationScope(AuthorizationScopes.Cart.Write)]
        [ProducesResponseType(typeof(CartModel), StatusCodes.Status200OK)]
        public async Task<CartModel> UpdateCartItems([FromBody] IEnumerable<CartItemUpdateModel> request)
        {
            return await _mediator.Send(new UpdateCartItemsRequest()
            {
                User = _identityProvider.Current,
                CartItemUpdates = request
            });
        }
    }
}