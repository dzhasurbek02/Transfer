using Microsoft.EntityFrameworkCore;
using Transfer.Entities;

namespace Transfer.Context;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Account> Accounts { get; set; }
    
    public DbSet<Transaction> Transactions { get; set; }
    
    public DbSet<Currency> Currencies { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}