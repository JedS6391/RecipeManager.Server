using RecipeIngredientParser.Core.Parser;

namespace RecipeManager.Core.Features.Recipes.Services.Abstract
{
    /// <summary>
    /// Defines a factory for <see cref="IngredientParser"/> instances.
    /// </summary>
    public interface IRecipeIngredientParserFactory
    {
        /// <summary>
        /// Gets a <see cref="IngredientParser"/> instance.
        /// </summary>
        /// <returns></returns>
        IngredientParser GetParser();
    }
}