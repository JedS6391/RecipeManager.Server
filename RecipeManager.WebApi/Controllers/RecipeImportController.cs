using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Features.Recipes.Models.Command;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Core.Features.Recipes.Queries.Requests;
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
        /// Gets the recipe import job with the given identifier.
        /// </summary>
        /// <param name="jobId"></param>
        [HttpGet]
        [Route("{jobId}")]
        [AuthorizationScope(AuthorizationScopes.Recipes.Read)]
        [ProducesResponseType(typeof(RecipeImportJobModel), StatusCodes.Status200OK)]
        public async Task<RecipeImportJobModel> GetImportJob(Guid jobId)
        {
            return await _mediator.Send(new GetRecipeImportJobQuery()
            {
                Id = jobId,
                User = _identityProvider.Current
            });
        }
        
        /// <summary>
        /// Creates an import job for a recipe for the current user.
        /// </summary>
        /// <param name="request"></param
        [HttpPost]
        [AuthorizationScope(AuthorizationScopes.Recipes.Write)]
        [ProducesResponseType(typeof(RecipeImportJobModel), StatusCodes.Status200OK)]
        public async Task<RecipeImportJobModel> CreateImportRecipeImportJob([FromBody] RecipeImportModel request)
        {
            return await _mediator.Send(new ImportRecipeRequest()
            {
                RecipeUrl = request.RecipeUrl,
                User = _identityProvider.Current
            });
        }
    }
}