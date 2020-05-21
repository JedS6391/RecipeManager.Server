using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Data.Configuration
{
    /// <inheritdoc/>
    public class RecipeImportJobConfiguration : IEntityTypeConfiguration<RecipeImportJob>
    {
        public void Configure(EntityTypeBuilder<RecipeImportJob> builder)
        {
            builder.ToTable("tblRecipeImportJob");

            builder.HasKey(j => j.Id);

            builder
                .Property(j => j.Id)
                .HasColumnName("recipeImportJob_id");

            builder
                .Property(j => j.UserId)
                .HasColumnName("recipeImportJob_userId");
            
            builder
                .Property(j => j.Status)
                .HasColumnName("recipeImportJob_status")
                .HasConversion<string>();
        }
    }
}