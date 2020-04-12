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
                .HasOne(i => i.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(i => i.RecipeId);
        }
    }
}