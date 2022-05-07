using System;
using MediatR;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Commands.Requests
{
    /// <summary>
    /// Represents a command request to delete the <see cref="Recipe"/> with a given identifier
    /// for a given user.
    /// </summary>
    public class DeleteRecipeByIdRequest : IRequest
    {
        /// <summary>
        /// Gets or sets the identifier of the <see cref="Recipe"/> to delete.
        /// </summary>
        public Guid RecipeId { get; set; }
        
        /// <summary>
        /// Gets or sets the user the recipe belongs to.
        /// </summary>
        public User User { get; set; }
    }
}