using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Interfaces;
using Identity.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Users.UpdateUser;

public record UpdateUserRequest : IRequest
{
    public required Guid Guid { get; init; }
    public required string NormalizedEmail { get; init; }
    public required ICollection<NormalizedName> Roles { get; init; }
    public required ICollection<Claim> PersonalClaims { get; init; }
};

public record Claim
{
    public required string Type { get; init; }
    public required string Value { get; init; }
}

internal class UpdateUserHandler : IRequestHandler<UpdateUserRequest>
{
    private readonly IIdentityDbContext _dbc;

    public UpdateUserHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var email = new NormalizedEmailAddress(request.NormalizedEmail);
        var user = await _dbc.Users.Where(p=>p.Guid == request.Guid)
            .Include(p=>p.Roles)
            .Include("UserClaims")
            .Include("EmailConfirmationToken")
            .Include("_passwordRecoveryTokens")
            .FirstOrDefaultAsync(cancellationToken);
        if (user is null)
        {
            throw new NotFoundException($"User {request.Guid} not found.");
        }

        var emailGuid = await _dbc.Users.AsNoTracking()
            .Where(p => p.NormalizedEmail == email).Select(p => p.Guid).FirstOrDefaultAsync(cancellationToken);
        if (email is not null && emailGuid != request.Guid)
        {
            throw new EmailInUseException("The email address is used by another user");
        }

        var allRoles = await _dbc.Roles.ToListAsync(cancellationToken);
        var roles = allRoles.Where(p =>
            request.Roles.Contains(p.NormalizedName)).ToList();
        
        var claims = request.PersonalClaims.Select(p => new Domain.UserClaim
        {
            ClaimType = p.Type,
            ClaimValue = p.Value
        }).ToList();
        
        user.NormalizedEmail = email!;
        
        user.RemovePersonalClaims();
        user.AddPersonalClaims(claims);
        
        user.Roles.Clear();
        foreach (var role in roles)
        {
            user.Roles.Add(role);
        }

        _dbc.Users.Update(user);
        await _dbc.SaveChangesAsync(cancellationToken);
    }
}