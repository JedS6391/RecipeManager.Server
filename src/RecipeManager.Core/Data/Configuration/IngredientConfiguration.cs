using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Data.EntityConfiguration
{
    /// <inheritdoc/>
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("tblIngredient");

            builder.HasKey(i => i.Id);

            builder
                .Property(i => i.Id)
                .HasColumnName("ingredient_id");

            builder
                .Property(i => i.RecipeId)
                .HasColumnName("ingredient_recipeId");

            builder
                .Property(i => i.Name)
                .HasColumnName("ingredient_name");

            builder
                .Property(i => i.Amount)
                .HasColumnName("ingredient_amount");
            
            builder
                .Property(i => i.CategoryId)
                .HasColumnName("ingredient_categoryId");

            builder
                .HasOne(i => i.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(i => i.RecipeId);
            
            builder
                .HasOne(i => i.Category)
                .WithMany(ic => ic.Ingredients)
                .HasForeignKey(i => i.CategoryId);
        }
    }
}