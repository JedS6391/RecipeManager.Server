using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeManager.Core.Features.Recipes.Models;
using RecipeManager.Core.Features.Recipes.Queries.Requests;

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

        [HttpGet]
        public async Task<IEnumerable<RecipeModel>> GetAll()
        {
            return await _mediator.Send(new GetAllQuery());
        }
    }
}
