﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Core.Features.Recipes.Models.Command;
using RecipeManager.Core.Features.Recipes.Queries.Requests;
using RecipeManager.WebApi.Security;

namespace RecipeManager.WebApi.Controllers
{ 
    [ApiController]
    [Authorize(Policy = AuthorizationScopeRequirement.PolicyName)]
    [Route("api/me/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IIdentityProvider _identityProvider;

        public RecipesController(
            IMediator mediator,
            IIdentityProvider identityProvider)
        {
            _mediator = mediator;
            _identityProvider = identityProvider;
        }
        
        /// <summary>
        /// Gets the details of all recipes defined for the current user.
        /// </summary>
        [HttpGet]
        [AuthorizationScope(AuthorizationScopes.Recipes.Read)]
        [ProducesResponseType(typeof(IEnumerable<RecipeModel>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<RecipeModel>> GetAll()
        {
            return await _mediator.Send(new GetAllRecipesQuery()
            {
                User = _identityProvider.Current
            });
        }

        /// <summary>
        /// Gets the details of the recipe with the specified ID for the current user.
        /// </summary>
        [HttpGet]
        [Route("{recipeId}")]
        [AuthorizationScope(AuthorizationScopes.Recipes.Read)]
        [ProducesResponseType(typeof(IEnumerable<RecipeModel>), StatusCodes.Status200OK)]
        public async Task<RecipeModel> GetById(Guid recipeId)
        {
            return await _mediator.Send(new GetRecipeByIdQuery()
            {
                Id = recipeId,
                User = _identityProvider.Current
            });
        }

        /// <summary>
        /// Gets the details of all ingredient categories defined for the current user.
        /// </summary>
        [HttpGet]
        [Route("ingredients/categories")]
        [AuthorizationScope(AuthorizationScopes.Recipes.Read)]
        [ProducesResponseType(typeof(IEnumerable<IngredientCategoryModel>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<IngredientCategoryModel>> GetAllIngredientCategories()
        {
            return await _mediator.Send(new GetAllIngredientCategoriesQuery()
            {
                User = _identityProvider.Current
            });
        }
        
        /// <summary>
        /// Gets the details of all recipe groups defined for the current user.
        /// </summary>
        [HttpGet]
        [Route("groups")]
        [AuthorizationScope(AuthorizationScopes.Recipes.Read)]
        [ProducesResponseType(typeof(IEnumerable<RecipeGroupModel>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<RecipeGroupModel>> GetAllRecipeGroups()
        {
            return await _mediator.Send(new GetAllRecipeGroupsQuery()
            {
                User = _identityProvider.Current
            });
        }

        /// <summary>
        /// Creates a new recipe for the current user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthorizationScope(AuthorizationScopes.Recipes.Write)]
        [ProducesResponseType(typeof(RecipeModel), StatusCodes.Status200OK)]
        public async Task<RecipeModel> CreateNew([FromBody] RecipeCreateModel request)
        {
            return await _mediator.Send(new CreateRecipeRequest()
            {
                Name = request.Name,
                User = _identityProvider.Current
            });
        }

        /// <summary>
        /// Updates a recipe for the current user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{recipeId}")]
        [AuthorizationScope(AuthorizationScopes.Recipes.Write)]
        [ProducesResponseType(typeof(RecipeModel), StatusCodes.Status200OK)]
        public async Task<RecipeModel> CreateNew(Guid recipeId, [FromBody] RecipeUpdateModel request)
        {
            return await _mediator.Send(new UpdateRecipeRequest()
            {
                RecipeId = recipeId,
                Name = request.Name,
                User = _identityProvider.Current
            });
        }


        /// <summary>
        /// Updates the instructions of the given recipe for the current user.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{recipeId}/ingredients")]
        [AuthorizationScope(AuthorizationScopes.Recipes.Write)]
        [ProducesResponseType(typeof(RecipeModel), StatusCodes.Status200OK)]
        public async Task<RecipeModel> UpdateInstructions(Guid recipeId, [FromBody] IEnumerable<IngredientCreateModel> request)
        {
            return await _mediator.Send(new UpdateRecipeIngredientsRequest()
            {
                RecipeId = recipeId,
                Ingredients = request,
                User = _identityProvider.Current
            });
        }
        
        /// <summary>
        /// Updates the groups of the given recipe for the current user.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{recipeId}/groups")]
        [AuthorizationScope(AuthorizationScopes.Recipes.Write)]
        [ProducesResponseType(typeof(RecipeModel), StatusCodes.Status200OK)]
        public async Task<RecipeModel> UpdateRecipeGroups(Guid recipeId, [FromBody] RecipeGroupUpdateModel request)
        {
            return await _mediator.Send(new UpdateRecipeGroupsRequest()
            {
                RecipeId = recipeId,
                RecipeGroupsToCreate = request.RecipeGroupsToCreate,
                RecipeGroupsToAssociate = request.RecipeGroupsToAssociate,
                User = _identityProvider.Current
            });
        }

        /// <summary>
        /// Deletes the recipe with the specified ID for the current user.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{recipeId}")]
        [AuthorizationScope(AuthorizationScopes.Recipes.Write)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task DeleteRecipe(Guid recipeId)
        {
            await _mediator.Send(new DeleteRecipeByIdRequest()
            {
                RecipeId = recipeId,
                User = _identityProvider.Current
            });
        }
    }
}
