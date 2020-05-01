using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Data.Configuration
{
    /// <inheritdoc/>
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("tblRecipe");

            builder.HasKey(r => r.Id);

            builder
                .Property(r => r.Id)
                .HasColumnName("recipe_id");

            builder
                .Property(r => r.Name)
                .HasColumnName("recipe_name");

            builder
                .Property(r => r.UserId)
                .HasColumnName("recipe_userId");

            builder.Ignore(r => r.RecipeGroups);

            builder
                .HasMany(r => r.Ingredients)
                .WithOne(i => i.Recipe)
                .HasForeignKey(i => i.RecipeId);

            builder
                .HasMany(r => r.Instructions)
                .WithOne(i => i.Recipe)
                .HasForeignKey(i => i.RecipeId);

            builder
                .HasMany(r => r.RecipeGroupLinks)
                .WithOne(rgl => rgl.Recipe)
                .HasForeignKey(rgl => rgl.RecipeId);
        }
    }
}
