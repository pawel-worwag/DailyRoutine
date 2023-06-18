using System.Reflection;
using Identity.Application.Common.Interfaces;
using Identity.Domain.Entities;
using Identity.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistence;

public class IdentityDbContext : IdentityDbContext<Domain.Entities.User, Domain.Entities.Role, int>,IIdentityDbContext
{
    public DbSet<Domain.Entities.RegistrationToken> RegistrationTokens { get; set; }
    public DbSet<Domain.Entities.RecoveryPasswordToken> RecoveryPasswordTokens { get; set; }
    public DbSet<Domain.Entities.Client> Clients { get; set; }

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
