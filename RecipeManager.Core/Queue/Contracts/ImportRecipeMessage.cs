namespace RecipeManager.Core.Queue.Contracts
{
    public class ImportRecipeMessage : Message
    {
        public string RecipeUrl { get; set; }
        public string UserId { get; set; }
    }
}