using Microsoft.EntityFrameworkCore;
using Transfer.Entities;

namespace Transfer.Context;

public interface IApplicationDBContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    
    public DbSet<Transaction> Transactions { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}