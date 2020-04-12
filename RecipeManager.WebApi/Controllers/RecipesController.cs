using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Features.Recipes.Models;
using RecipeManager.Core.Features.Recipes.Queries.Requests;
using RecipeManager.WebApi.Security;

namespace RecipeManager.WebApi.Controllers
{ 
    [ApiController]
    [Authorize]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets the details of all recipes defined.
        /// </summary>
        [HttpGet]
        [Route("{recipeId}")]
        [AuthorizationScope(AuthorizationScopes.Recipes.Read)]
        [ProducesResponseType(typeof(IEnumerable<RecipeModel>), StatusCodes.Status200OK)]
        public async Task<RecipeModel> GetById(Guid recipeId)
        {
            return await _mediator.Send(new GetRecipeByIdQuery()
            {
                Id = recipeId
            });
        }

        /// <summary>
        /// Gets the details of the recipe with the specified ID.
        /// </summary>
        [HttpGet]
        [AuthorizationScope(AuthorizationScopes.Recipes.Read)]
        [ProducesResponseType(typeof(IEnumerable<RecipeModel>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<RecipeModel>> GetAll()
        {
            return await _mediator.Send(new GetAllRecipesQuery());
        }

        [HttpPost]
        [AuthorizationScope(AuthorizationScopes.Recipes.Write)]
        [ProducesResponseType(typeof(RecipeModel), StatusCodes.Status200OK)]
        public async Task<RecipeModel> Post([FromBody] CreateRecipeRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
