using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Common.Interfaces;

public interface IIdentityDbContext
{
    DbSet<Domain.Entities.RegistrationToken>  RegistrationTokens { get; set; }
    DbSet<Domain.Entities.RecoveryPasswordToken> RecoveryPasswordTokens { get; set; }
    DbSet<Domain.Entities.Client> Clients { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}