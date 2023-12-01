using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transfer.Entities;

namespace Transfer.Configurations;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(pm => pm.Id);
        
        builder.Property(pm => pm.Balance)
            .IsRequired();

        builder.HasOne<User>(pm => pm.User)
            .WithMany(u => u.Accounts)
            .HasForeignKey(pm => pm.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Currency>(pm => pm.Currency)
            .WithMany(c => c.Accounts)
            .HasForeignKey(pm => pm.CurrencyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}