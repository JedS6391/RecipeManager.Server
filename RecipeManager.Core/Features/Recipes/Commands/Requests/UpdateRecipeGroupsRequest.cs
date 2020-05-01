using System;
using System.Collections.Generic;
using MediatR;
using RecipeManager.Core.Features.Recipes.Models.Command;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Commands.Requests
{
    /// <summary>
    /// A request to update the <see cref="RecipeGroup"/>s of a <see cref="Recipe"/>.
    /// </summary>
    public class UpdateRecipeGroupsRequest : IRequest<RecipeModel>
    {
        /// <summary>
        /// Gets or sets the identifier of the recipe to update.
        /// </summary>
        public Guid RecipeId { get; set; }
        
        /// <summary>
        /// Gets or sets a collection of recipe groups to be created and associated with the recipe.
        /// </summary>
        public IEnumerable<RecipeGroupCreateModel> RecipeGroupsToCreate { get; set; }
        
        /// <summary>
        /// Gets or sets a collection of existing recipes groups to associate with the recipe.
        /// </summary>
        public IEnumerable<RecipeGroupAssociateModel> RecipeGroupsToAssociate { get; set; }
        
        /// <summary>
        /// Gets or sets the user the recipe belongs to.
        /// </summary>
        public User User { get; set; }
    }
}