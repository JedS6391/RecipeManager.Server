using System.Threading.Tasks;
using RecipeManager.Core.Queue.Contracts;

namespace RecipeManager.Core.Features.Recipes.Services.Abstract
{
    public interface IRecipeImporterService
    {
        Task ImportRecipe(ImportRecipeMessage importRecipeMessage);
    }
}