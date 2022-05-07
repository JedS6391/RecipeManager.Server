using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Data.Configuration
{
    /// <inheritdoc/>
    public class RecipeGroupConfiguration : IEntityTypeConfiguration<RecipeGroup>
    {
        public void Configure(EntityTypeBuilder<RecipeGroup> builder)
        {
            builder.ToTable("tblRecipeGroup");

            builder.HasKey(rg => rg.Id);

            builder
                .Property(rg => rg.Id)
                .HasColumnName("recipeGroup_id");

            builder
                .Property(rg => rg.UserId)
                .HasColumnName("recipeGroup_userId");
            
            builder
                .Property(rg => rg.Name)
                .HasColumnName("recipeGroup_name");

            builder.Ignore(rg => rg.Recipes);

            builder
                .HasMany(rg => rg.RecipeGroupLinks)
                .WithOne(rgl => rgl.RecipeGroup)
                .HasForeignKey(rgl => rgl.RecipeGroupId);
        }
    }
}