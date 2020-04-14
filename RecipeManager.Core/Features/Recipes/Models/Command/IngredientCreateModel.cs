namespace RecipeManager.Core.Features.Recipes.Models.Command
{
    /// <summary>
    /// Defines a model for creating an ingredient.
    /// </summary>
    public class IngredientCreateModel
    {
        /// <summary>
        /// Gets or sets the name of the ingredient.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the amount of the ingredient.
        /// </summary>
        public string Amount { get; set; }
    }
}
