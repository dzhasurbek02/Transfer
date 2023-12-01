using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transfer.Entities;

namespace Transfer.Configurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Type)
            .HasMaxLength(30)
            .IsRequired();

    }
}