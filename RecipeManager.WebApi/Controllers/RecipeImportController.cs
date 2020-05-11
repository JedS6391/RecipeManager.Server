using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Features.Recipes.Models.Command;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.WebApi.Security;

namespace RecipeManager.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/me/recipes/import")]
    public class RecipeImportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IIdentityProvider _identityProvider;

        public RecipeImportController(
            IMediator mediator,
            IIdentityProvider identityProvider)
        {
            _mediator = mediator;
            _identityProvider = identityProvider;
        }
        
        /// <summary>
        /// Starts the import process for a recipe for the current user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthorizationScope(AuthorizationScopes.Recipes.Write)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task ImportRecipe([FromBody] RecipeImportModel request)
        {
            await _mediator.Send(new ImportRecipeRequest()
            {
                RecipeUrl = request.RecipeUrl,
                User = _identityProvider.Current
            });
        }
    }
}