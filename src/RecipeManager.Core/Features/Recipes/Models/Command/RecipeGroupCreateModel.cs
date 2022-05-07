namespace RecipeManager.Core.Features.Recipes.Models.Command
{
    /// <summary>
    /// Defines a model to create a <see cref="RecipeGroup"/>.
    /// </summary>
    public class RecipeGroupCreateModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}