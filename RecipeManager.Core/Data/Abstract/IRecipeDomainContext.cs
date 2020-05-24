using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Data.Abstract
{
    /// <summary>
    /// Defines the domain context for recipes.
    /// </summary>
    public interface IRecipeDomainContext
    {
        /// <summary>
        /// Gets or sets the <see cref="Recipe"/> entities.
        /// </summary>
        DbSet<Recipe> Recipes { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="RecipeGroup"/> entities.
        /// </summary>
        DbSet<RecipeGroup> RecipeGroups { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Ingredient"/> entities.
        /// </summary>
        DbSet<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IngredientCategory"/> entities.
        /// </summary>
        DbSet<IngredientCategory> IngredientCategories { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="Instruction"/> entities.
        /// </summary>
        DbSet<Instruction> Instructions { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="Cart"/> entities.
        /// </summary>
        DbSet<Cart> Carts { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="CartItems"/> entities.
        /// </summary>
        DbSet<CartItem> CartItems { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="RecipeImportJob"/> entities.
        /// </summary>
        DbSet<RecipeImportJob> RecipeImportJobs { get; set; }

        /// <summary>
        /// Saves all changes made in this context.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
