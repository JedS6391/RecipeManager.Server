using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Data
{
    /// <summary>
    /// An implementation of <see cref="IRecipeDomainContext"/> which utilises a SQL server database.
    /// </summary>
    public class RecipeDomainContext : DbContext, IRecipeDomainContext
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public RecipeDomainContext(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        /// <inheritdoc/>
        public DbSet<Recipe> Recipes { get; set; }

        /// <inheritdoc/>
        public DbSet<Ingredient> Ingredients { get; set; }

        /// <inheritdoc/>
        public DbSet<Instruction> Instructions { get; set; }
        
        /// <inheritdoc/>
        public DbSet<Cart> Carts { get; set; }
        
        /// <inheritdoc/>
        public DbSet<CartItem> CartItems { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null || optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(_connectionStringProvider.ConnectionString);
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeDomainContext).Assembly);
        }

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
