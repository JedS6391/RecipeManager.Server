using System;
using MediatR;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Queries.Requests
{    
    /// <summary>
    /// Represents a query request for a specific <see cref="RecipeImportJob"/> instance for a user.
    /// </summary>
    public class GetRecipeImportJobQuery : IRequest<RecipeImportJobModel>
    {
        /// <summary>
        /// Gets or sets the <see cref="RecipeImportJob"/> identifier
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Gets or sets the user for which recipes will be searched.
        /// </summary>
        public User User { get; set; }
    }
}