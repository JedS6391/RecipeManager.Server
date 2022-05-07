using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Data.Configuration
{
    /// <inheritdoc/>
    public class RecipeGroupLinkConfiguration : IEntityTypeConfiguration<RecipeGroupLink>
    {
        public void Configure(EntityTypeBuilder<RecipeGroupLink> builder)
        {
            builder.ToTable("tblRecipeGroupLink");

            builder.HasKey(rgl => new
            {
                rgl.RecipeGroupId,
                rgl.RecipeId
            });

            builder
                .Property(rgl => rgl.RecipeGroupId)
                .HasColumnName("recipeGroupLink_recipeGroupId");

            builder
                .Property(rgl => rgl.RecipeId)
                .HasColumnName("recipeGroupLink_recipeId");

            builder
                .HasOne(rgl => rgl.RecipeGroup)
                .WithMany(rg => rg.RecipeGroupLinks)
                .HasForeignKey(rgl => rgl.RecipeGroupId);
            
            builder
                .HasOne(rgl => rgl.Recipe)
                .WithMany(r => r.RecipeGroupLinks)
                .HasForeignKey(rgl => rgl.RecipeId);
        }
    }
}