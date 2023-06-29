using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Auth.Clients.VerifyClient;

public record VerifyClientRequest : IRequest<ClientVerifyResult>
{
    public required Guid ClientId { get; init; }
    public required string RedirectUri { get; init; }
}

internal class Handler : IRequestHandler<VerifyClientRequest, ClientVerifyResult>
{
    private readonly IIdentityDbContext _dbc;

    public Handler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<ClientVerifyResult> Handle(VerifyClientRequest request, CancellationToken cancellationToken)
    {
        try
        {
        var client = await _dbc.Clients.Where(p => p.Guid == request.ClientId).Include(p => p.RedirectionEndpoints)
            .FirstOrDefaultAsync(cancellationToken);

        
        if (client is null)
        {
            return new ClientVerifyResult()
            {
                IsValid = false,
                Error = $"Unauthorized client - '{request.ClientId.ToString()}'."
            };
        }

        var uri = client.RedirectionEndpoints.FirstOrDefault(p => p.Uri == request.RedirectUri);
        
        if ( uri is null)
        {
            return new ClientVerifyResult()
            {
                IsValid = false,
                Error = $"Unauthorized redirect uri - '{request.RedirectUri}'."
            };
        }
        return new ClientVerifyResult();

        }
        catch (Exception e)
        {
            return new ClientVerifyResult()
            {
                IsValid = false,
                Error = $"Internal error: {e.Message}"
            };
        }
    }
}