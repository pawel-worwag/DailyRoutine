using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Auth.AuthorizationValidate;

public record AuthorizationValidateRequest : IRequest
{
    public string? ResponseType { get; init; } = null;
    public string? ClientId { get; init; } = null;
    public string? RedirectUri { get; init; } = null;
    public string? Scope { get; init; } = null;
    public string? State { get; init; } = null;
}

internal class AuthorizationValidateHandler : IRequestHandler<AuthorizationValidateRequest>
{
    private IIdentityDbContext _dbc;

    public AuthorizationValidateHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task Handle(AuthorizationValidateRequest request, CancellationToken cancellationToken)
    {
        var client = await _dbc.Clients.Where(p => p.Guid.ToString() == request.ClientId)
            .Include(p=>p.RedirectionEndpoints)
            .FirstOrDefaultAsync(cancellationToken);
        if (client is null)
        {
            throw new Exception("Bad client");
        }

        var endpoint = client.RedirectionEndpoints.FirstOrDefault(p => p.Uri == request.RedirectUri);
        if (endpoint is null)
        {
            throw new Exception("Bad redirect endpoint");
        }
    }
}