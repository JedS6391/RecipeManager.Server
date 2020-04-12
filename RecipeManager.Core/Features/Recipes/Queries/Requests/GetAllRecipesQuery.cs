using System.Collections.Generic;
using MediatR;
using RecipeManager.Core.Features.Recipes.Models;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Queries.Requests
{
    /// <summary>
    /// Represents a query request for all <see cref="Recipe"/> instances.
    /// </summary>
    /// <remarks>
    /// Note that a read-only view of <see cref="RecipeModel"/>s is returned.
    /// </remarks>
    public class GetAllRecipesQuery : IRequest<IEnumerable<RecipeModel>>
    {
    }
}
