using System.Collections.Generic;
using MediatR;
using RecipeManager.Core.Features.Recipes.Models;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Queries.Requests
{
    /// <summary>
    /// Represents a query request for all <see cref="Recipe"/> instances belonging to the specified user.
    /// </summary>
    /// <remarks>
    /// Note that a read-only view of <see cref="RecipeModel"/>s is returned.
    /// </remarks>
    public class GetAllRecipesQuery : IRequest<IEnumerable<RecipeModel>>
    {
        /// <summary>
        /// Gets or sets the user for which recipes will be searched.
        /// </summary>
        public User User { get; set; }
    }
}
