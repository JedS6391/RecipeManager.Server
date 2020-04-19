using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Data.Configuration
{
    /// <inheritdoc/>
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("tblCart");

            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .HasColumnName("cart_id");

            builder
                .Property(c => c.UserId)
                .HasColumnName("cart_userId");

            builder
                .Property(c => c.CreatedAt)
                .HasColumnName("cart_createdDate");

            builder
                .Property(c => c.IsCurrent)
                .HasColumnName("cart_isCurrent");

            builder
                .HasMany(c => c.Items)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);
        }
    }
}