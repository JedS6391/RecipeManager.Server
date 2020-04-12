using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Data.EntityConfiguration
{
    /// <inheritdoc/>
    public class InstructionConfiguration : IEntityTypeConfiguration<Instruction>
    {
        public void Configure(EntityTypeBuilder<Instruction> builder)
        {
            builder.ToTable("tblInstruction");

            builder.HasKey(i => i.Id);

            builder
                .Property(i => i.Id)
                .HasColumnName("instruction_id");

            builder
                .Property(i => i.RecipeId)
                .HasColumnName("instruction_recipeId");

            builder
                .Property(i => i.Sequence)
                .HasColumnName("instruction_sequence");

            builder
                .Property(i => i.Details)
                .HasColumnName("instruction_details");

            builder
                .HasOne(i => i.Recipe)
                .WithMany(r => r.Instructions)
                .HasForeignKey(i => i.RecipeId);
        }
    }
}