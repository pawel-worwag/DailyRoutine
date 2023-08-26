using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Users.GetUserDetails;

public record GetUserDetailsRequest : IRequest<Response>
{
    public required Guid Guid { get; init; }
};

internal class GetUserDetailsHandler : IRequestHandler<GetUserDetailsRequest, Response>
{
    private readonly IIdentityDbContext _dbc;

    public GetUserDetailsHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetUserDetailsRequest request, CancellationToken cancellationToken)
    {
        var user = await _dbc.Users.AsNoTracking()
            .Where(p => p.Guid == request.Guid)
            .Include(p => p.Roles)
            .Include("UserClaims")
            .Include("EmailConfirmationToken")
            .Include("_passwordRecoveryTokens")
            .FirstOrDefaultAsync(cancellationToken);
        if (user is null)
        {
            throw new NotFoundException($"User {request.Guid} not found.");
        }

        return new Response
        {
            Guid = user.Guid,
            NormalizedEmailAddress = user.NormalizedEmail.Value,
            EmailStatus = (EmailStatus) user.EmailStatus,
            Roles = user.Roles.Select(p=>new Role
            {
                NormalizedName = p.NormalizedName.Value
            }).ToList(),
            PersonalClaims = user.PersonalClaims.Select(p=> new Claim
            {
                Type = p.Type,
                Value = p.Value
            }).ToList(),
            RecoveryTokens = user.PasswordRecoveryTokens.Select(p=>new RecoveryToken
            {
                ValidAfter = p.ValidAfter,
                ValidBefore = p.ValidBefore
            }).ToList()
        };
    }
}