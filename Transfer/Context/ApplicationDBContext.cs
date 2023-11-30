using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Transfer.Entities;

namespace Transfer.Context;

public class ApplicationDBContext : DbContext, IApplicationDBContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    
    public DbSet<Transaction> Transactions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(builder);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}