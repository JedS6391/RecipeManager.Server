namespace RecipeManager.Core.Queue.Contracts
{
    /// <summary>
    /// Defines a message for importing a recipe.
    /// </summary>
    public class ImportRecipeMessage : Message
    {
        /// <summary>
        /// Gets or sets the URL where the recipe details can be retreived from.
        /// </summary>
        public string RecipeUrl { get; set; }
        
        /// <summary>
        /// Gets or sets the identifier of the user requesting the import.
        /// </summary>
        public string UserId { get; set; }
    }
}