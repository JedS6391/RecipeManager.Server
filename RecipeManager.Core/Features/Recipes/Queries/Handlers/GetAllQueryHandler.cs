using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeManager.Core.Features.Recipes.Models;
using RecipeManager.Core.Features.Recipes.Queries.Requests;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Queries.Handlers
{
    /// <summary>
    /// Handles <see cref="GetAllQuery"/> requests.
    /// </summary>
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<RecipeModel>>
    {
        private readonly Recipe[] _recipes;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllQueryHandler"/> class.
        /// </summary>
        public GetAllQueryHandler()
        {
            _recipes = new Recipe[]
            {
                new Recipe()
                {
                    Id = System.Guid.NewGuid(),
                    Name = "Test Recipe",
                    Ingredients = new Ingredient[] {},
                    Instructions = new Instruction[] { }
                }
            };
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RecipeModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return _recipes.Select(RecipeModel.From);
        }
    }
}
