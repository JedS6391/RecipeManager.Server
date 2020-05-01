using System.Collections.Generic;
using MediatR;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Queries.Requests
{
    /// <summary>
    /// Represents a query request for all <see cref="RecipeGroup"/> instances belonging to the specified user.
    /// </summary>
    public class GetAllRecipeGroupsQuery : IRequest<IEnumerable<RecipeGroupModel>>
    {
        /// <summary>
        /// Gets or sets the user for which recipe groups will be searched.
        /// </summary>
        public User User { get; set; }
    }
}