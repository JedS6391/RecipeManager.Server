using System;
using MediatR;
using RecipeManager.Core.Features.Recipes.Models;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Queries.Requests
{
    /// <summary>
    /// Represents a query request for a specific <see cref="Recipe"/> instance in a specific users collection.
    /// </summary>
    /// <remarks>
    /// Note that a read-only view of <see cref="RecipeModel"/>s is returned.
    /// </remarks>
    public class GetRecipeByIdQuery : IRequest<RecipeModel>
    {
        /// <summary>
        /// Gets or sets the identifier of the recipe to fetch.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user for which recipes will be searched.
        /// </summary>
        public User User { get; set; }
    }
}
