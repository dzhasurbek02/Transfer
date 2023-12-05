using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transfer.Entities;

namespace Transfer.Configurations;

public class ExchangeRate : IEntityTypeConfiguration<Entities.ExchangeRate>
{
    public void Configure(EntityTypeBuilder<Entities.ExchangeRate> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Rate)
            .IsRequired();

        builder.HasOne<Currency>(r => r.CurrencySender)
            .WithMany()
            .HasForeignKey(r => r.Currency1Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Currency>(r => r.CurrencyRecipient)
            .WithMany()
            .HasForeignKey(r => r.Currency2Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}