using System.Reflection;
using Identity.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistence;

public class IdentityDbContext : DbContext,IIdentityDbContext
{
    public DbSet<Domain.User> Users { get; set; } = default!;
    public DbSet<Domain.Role> Roles { get; set; } = default!;
    
    public DbSet<Domain.Entities.PasswordRecoveryToken> RecoveryPasswordTokens { get; set; } = default!;
    public DbSet<Domain.Entities.Client> Clients { get; set; } = default!;

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
    }

    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
