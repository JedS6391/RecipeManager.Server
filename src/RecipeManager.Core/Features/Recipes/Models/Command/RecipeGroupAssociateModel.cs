using System;

namespace RecipeManager.Core.Features.Recipes.Models.Command
{
    /// <summary>
    /// Defines a model to associate a <see cref="RecipeGroup"/> to a <see cref="Recipe"/>.
    /// </summary>
    public class RecipeGroupAssociateModel
    {
        public Guid RecipeGroupId { get; set; }
    }
}