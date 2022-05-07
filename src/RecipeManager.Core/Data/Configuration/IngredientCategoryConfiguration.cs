using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Data.Configuration
{
    /// <inheritdoc/>
    public class IngredientCategoryConfiguration : IEntityTypeConfiguration<IngredientCategory>
    {
        public void Configure(EntityTypeBuilder<IngredientCategory> builder)
        {
            builder.ToTable("tblIngredientCategory");

            builder.HasKey(ic => ic.Id);

            builder
                .Property(ic => ic.Id)
                .HasColumnName("ingredientCategory_id");

            builder
                .Property(ic => ic.UserId)
                .HasColumnName("ingredientCategory_userId");

            builder
                .Property(ic => ic.Name)
                .HasColumnName("ingredientCategory_name");

            builder
                .HasMany(ic => ic.Ingredients)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId);
        }
    }
}