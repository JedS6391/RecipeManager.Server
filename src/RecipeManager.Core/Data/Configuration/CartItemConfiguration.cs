using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Data.Configuration
{
    /// <inheritdoc/>
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("tblCartItem");

            builder.HasKey(ci => ci.Id);

            builder
                .Property(ci => ci.Id)
                .HasColumnName("cartItem_id");

            builder
                .Property(ci => ci.CartId)
                .HasColumnName("cartItem_cartId");

            builder
                .Property(ci => ci.CreatedAt)
                .HasColumnName("cartItem_createdDate");

            builder
                .Property(ci => ci.IngredientId)
                .HasColumnName("cartItem_ingredientId");

            builder
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CartId);

            builder
                .HasOne(ci => ci.Ingredient)
                .WithMany()
                .HasForeignKey(ci => ci.IngredientId);
        }
    }
}