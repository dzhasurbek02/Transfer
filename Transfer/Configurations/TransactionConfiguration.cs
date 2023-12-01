using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transfer.Entities;

namespace Transfer.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Sum)
            .IsRequired();

        builder.Property(t => t.TransactionDate)
            .IsRequired();

        builder.HasOne<Account>(t => t.Sender)
            .WithMany()
            .HasForeignKey(t => t.SenderId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Account>(t => t.Recipient)
            .WithMany()
            .HasForeignKey(t => t.RecipientId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}