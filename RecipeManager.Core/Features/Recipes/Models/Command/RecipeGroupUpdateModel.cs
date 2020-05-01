using System.Collections.Generic;

namespace RecipeManager.Core.Features.Recipes.Models.Command
{
    /// <summary>
    /// Defines a model for an update to the <see cref="RecipeGroup"/>s of a <see cref="Recipe"/>.
    /// </summary>
    public class RecipeGroupUpdateModel
    {
        /// <summary>
        /// Gets or sets a collection of recipe group details for creation and association.
        /// </summary>
        public IEnumerable<RecipeGroupCreateModel> RecipeGroupsToCreate { get; set; }
        
        /// <summary>
        /// Gets or sets a collection of existing recipe group details for association.
        /// </summary>
        public IEnumerable<RecipeGroupAssociateModel> RecipeGroupsToAssociate { get; set; }
    }
}