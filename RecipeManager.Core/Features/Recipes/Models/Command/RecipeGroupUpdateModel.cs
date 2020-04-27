using System;
using System.Collections.Generic;

namespace RecipeManager.Core.Features.Recipes.Models.Command
{
    public class RecipeGroupUpdateModel
    {
        public IEnumerable<RecipeGroupCreateModel> RecipeGroupsToCreate { get; set; }
        public IEnumerable<RecipeGroupAssociateModel> RecipeGroupsToAssociate { get; set; }
    }
}