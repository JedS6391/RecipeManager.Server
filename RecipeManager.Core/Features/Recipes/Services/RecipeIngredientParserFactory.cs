using RecipeIngredientParser.Core.Parser;
using RecipeIngredientParser.Core.Parser.Extensions;
using RecipeIngredientParser.Core.Parser.Strategy;
using RecipeIngredientParser.Core.Tokens;
using RecipeIngredientParser.Core.Tokens.Abstract;
using RecipeManager.Core.Features.Recipes.Services.Abstract;

namespace RecipeManager.Core.Features.Recipes.Services
{
    /// <inheritdoc/>
    public class RecipeIngredientParserFactory : IRecipeIngredientParserFactory
    {
        /// <inheritdoc/>
        public IngredientParser GetParser()
        {
            var parserBuilder = IngredientParser
                .Builder
                .New
                .WithDefaultConfiguration()
                .WithParserStrategy(
                    new BestFullMatchParserStrategy(
                        BestMatchHeuristics.WeightedTokenHeuristic(TokenWeightResolver)));

            return parserBuilder.Build();
        }
        
        private static decimal TokenWeightResolver(IToken token) 
        {
            switch (token)
            {
                case LiteralToken literalToken:
                    // Longer literals score more - the assumption being that
                    // a longer literal means a more specific value.
                    return 0.1m * literalToken.Value.Length;
                    
                case LiteralAmountToken _:
                case FractionalAmountToken _:
                case RangeAmountToken _:
                    return 1.0m;
                    
                case UnitToken unitToken:
                    return unitToken.Type == UnitType.Unknown ?
                        // Punish unknown unit types
                        -1.0m :
                        1.0m;
                    
                case FormToken _:
                    return 1.0m;
                    
                case IngredientToken _:
                    return 2.0m;
            }

            return 0.0m;
        }
    }
}