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
        /// Gets or sets the <see cref="Ingredient"/> entities.
        /// </summary>
        DbSet<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Instruction"/> entities.
        /// </summary>
        DbSet<Instruction> Instructions { get; set; }
    }
}
