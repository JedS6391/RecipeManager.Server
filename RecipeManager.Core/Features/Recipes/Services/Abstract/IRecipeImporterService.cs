using System.Threading.Tasks;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Features.Recipes.Services.Abstract
{
    /// <summary>
    /// Defines a service for import recipes.
    /// </summary>
    public interface IRecipeImporterService
    {
        /// <summary>
        /// Imports the recipe based on the provided message.
        /// </summary>
        /// <param name="importRecipeMessage"></param>
        /// <returns></returns>
        Task ImportRecipe(ImportRecipeMessage importRecipeMessage);
    }
}