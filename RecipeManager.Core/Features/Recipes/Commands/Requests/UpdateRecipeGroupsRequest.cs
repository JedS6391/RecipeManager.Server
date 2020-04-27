using System;
using System.Collections.Generic;
using MediatR;
using RecipeManager.Core.Features.Recipes.Models.Command;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Commands.Requests
{
    public class UpdateRecipeGroupsRequest : IRequest<RecipeModel>
    {
        public Guid RecipeId { get; set; }
        
        public IEnumerable<RecipeGroupCreateModel> RecipeGroupsToCreate { get; set; }
        
        public IEnumerable<RecipeGroupAssociateModel> RecipeGroupsToAssociate { get; set; }
        
        public User User { get; set; }
    }
}