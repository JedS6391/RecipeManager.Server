namespace RecipeManager.Core.Features.Recipes.Models.Command
{
    /// <summary>
    /// Defines a model for importing a recipe.
    /// </summary>
    public class RecipeImportModel
    {
        /// <summary>
        /// Gets or sets the URL where the recipe details can be retreived from.
        /// </summary>
        public string RecipeUrl { get; set; }
    }
}