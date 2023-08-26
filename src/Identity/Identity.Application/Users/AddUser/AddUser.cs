using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Interfaces;
using Identity.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Users.AddUser;

public record AddUserRequest : IRequest<Guid>
{
    public required string NormalizedEmail { get; init; }
    public required ICollection<NormalizedName> Roles { get; init; }
    public required ICollection<Claim> PersonalClaims { get; init; }
};

public record Claim
{
    public required string Type { get; init; }
    public required string Value { get; init; }
}

internal class AddUserHandler : IRequestHandler<AddUserRequest, Guid>
{
    private readonly IIdentityDbContext _dbc;

    public AddUserHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Guid> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        var email = new NormalizedEmailAddress(request.NormalizedEmail);
        var count = await _dbc.Users.AsNoTracking()
            .Where(p => p.NormalizedEmail == email)
            .CountAsync(cancellationToken);
        if (count != 0)
        {
            throw new EmailInUseException($"The email address is already in use.");
        }

        var allRoles = await _dbc.Roles.ToListAsync(cancellationToken);
        var roles = allRoles.Where(p =>
            request.Roles.Contains(p.NormalizedName)).ToList();

        var claims = request.PersonalClaims.Select(p => new Domain.UserClaim
        {
            ClaimType = p.Type,
            ClaimValue = p.Value
        }).ToList();

        var user = new Domain.User
        {
            NormalizedEmail = email
        };
        user.AddPersonalClaims(claims);
        foreach (var role in roles)
        {
            user.Roles.Add(role);
        }

        _dbc.Users.Add(user);
        await _dbc.SaveChangesAsync(cancellationToken);
        return user.Guid;
    }
}