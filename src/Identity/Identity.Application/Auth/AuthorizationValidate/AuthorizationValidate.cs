using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Auth.AuthorizationValidate;

public record AuthorizationValidateRequest : IRequest
{
    public string? ResponseType { get; init; } = null;
    public Guid? ClientId { get; init; } = null;
    public string? RedirectUri { get; init; } = null;
    public string? Scope { get; init; } = null;
    public string? State { get; init; } = null;
}

internal class AuthorizationValidateHandler : IRequestHandler<AuthorizationValidateRequest>
{
    private IIdentityDbContext _dbc;
    private readonly ICollection<string> _allowedResponses = new List<string>() { "token", "code" };

    public AuthorizationValidateHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task Handle(AuthorizationValidateRequest request, CancellationToken cancellationToken)
    {
        if (request.ResponseType is null)
        {
            throw new Exception("Empty response_type.");  
        }
        
        if (!_allowedResponses.Contains(request.ResponseType))
        {
            throw new Exception("Unsupported response_type.");
        }

        if (request.ClientId is null)
        {
            throw new Exception("Empty client_id.");
        }

        switch (request.ResponseType)
        {
            case "code":
            {
                var client = await _dbc.Clients.Include(p => p.RedirectionEndpoints).FirstOrDefaultAsync(p => p.Guid == request.ClientId,cancellationToken);
                if (client is null)
                {
                    throw new Exception("Unknown client_id");
                }
                
                break;
            }
            case "token":
            {
                break;
            }
        }
    }
}