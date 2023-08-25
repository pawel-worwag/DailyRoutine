using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Common.Interfaces;

public interface IIdentityDbContext
{
    DbSet<Domain.User> Users { get; set; }
    DbSet<Domain.Role> Roles { get; set; }
    DbSet<Domain.Client> Clients { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}