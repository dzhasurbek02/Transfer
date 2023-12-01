using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Transfer.Entities;

namespace Transfer.Context;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Account> PaymentMethods { get; set; }
    
    public DbSet<Transaction> Transactions { get; set; }
    
    public DbSet<Currency> Currencies { get; set; }

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