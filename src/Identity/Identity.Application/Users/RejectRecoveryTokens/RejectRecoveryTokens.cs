using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Users.RejectRecoveryTokens;

public record RejectRecoveryTokensRequest : IRequest
{
    public required Guid Guid { get; init; }
}

internal class RejectRecoveryTokensHandler : IRequestHandler<RejectRecoveryTokensRequest>
{
    private readonly IIdentityDbContext _dbc;

    public RejectRecoveryTokensHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task Handle(RejectRecoveryTokensRequest request, CancellationToken cancellationToken)
    {
        var user = await _dbc.Users.Include(p => p.Roles)
            .Include("UserClaims")
            .Include("EmailConfirmationToken")
            .Include("_passwordRecoveryTokens")
            .FirstOrDefaultAsync(p => p.Guid == request.Guid, cancellationToken);
        if (user is null)
        {
            throw new NotFoundException($"User {request.Guid} not found");
        }
        user.RemoveRecoveryTokens();
        _dbc.Users.Update(user);
        await _dbc.SaveChangesAsync(cancellationToken);
    }
}