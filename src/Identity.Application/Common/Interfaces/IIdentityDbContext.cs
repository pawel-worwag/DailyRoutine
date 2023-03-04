namespace Identity.Application.Common.Interfaces;

public interface IIdentityDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}