using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Domain.Entities;
using RecipeManager.Domain.Entities.Abstract;

namespace RecipeManager.Core.Data.Extensions
{
    /// <summary>
    /// Defines extensions for common functionality of <see cref="IRecipeDomainContext"/>.
    /// </summary>
    public static class RecipeDomainContextExtensions
    {
        /// <summary>
        /// Gets the current cart for the given user from the domain context.
        /// </summary>
        /// <param name="recipeDomainContext"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<Cart> GetCurrentCart(this IRecipeDomainContext recipeDomainContext, User user)
        {
            return await recipeDomainContext
                .Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Ingredient)
                .ThenInclude(i => i.Category)
                .ForUser(user)
                .FirstOrDefaultAsync(c => c.IsCurrent);
        }

        /// <summary>
        /// Gets all recipes for the given user from the domain context.
        /// </summary>
        /// <param name="recipeDomainContext"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static IQueryable<Recipe> GetRecipesForUser(this IRecipeDomainContext recipeDomainContext, User user)
        {
            return recipeDomainContext
                .Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Category)
                .Include(r => r.Instructions)
                .Include(r => r.RecipeGroupLinks)
                .ThenInclude(rgl => rgl.RecipeGroup)
                .ForUser(user);
        }

        /// <summary>
        /// Filters a set of entities to those for the specified user.
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="user"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static IQueryable<TEntity> ForUser<TEntity>(
            this IQueryable<TEntity> queryable, 
            User user)
            where TEntity : IUserIdentifiable
        {
            return queryable.Where(e => e.UserId == user.Id);
        }
    }
}