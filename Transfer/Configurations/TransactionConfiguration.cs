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

        builder.HasOne<PaymentMethod>(t => t.Sender)
            .WithMany(pm => pm.Transactions)
            .HasForeignKey(t => t.SenderId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PaymentMethod>(t => t.Recipient)
            .WithMany(pm => pm.Transactions)
            .HasForeignKey(t => t.RecipientId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}