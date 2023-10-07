using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Auth.AuthorizationValidate;

public record AuthorizationValidateRequest : IRequest<ValidationResult>
{
    public string? ResponseType { get; init; } = null;
    public Guid? ClientId { get; init; } = null;
    public string? RedirectUri { get; init; } = null;
    public string? Scope { get; init; } = null;
    public string? State { get; init; } = null;
}

internal class AuthorizationValidateHandler : IRequestHandler<AuthorizationValidateRequest,ValidationResult>
{
    private IIdentityDbContext _dbc;
    private readonly ICollection<string> _allowedResponses = new List<string>() { "token", "code" };

    public AuthorizationValidateHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<ValidationResult> Handle(AuthorizationValidateRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<string>();
        
        if (request.ResponseType is null) { errors.Add("Empty response_type."); }
        else
        {
            if (!_allowedResponses.Contains(request.ResponseType)) { errors.Add("Unsupported response_type."); } 
        }

        if (request.ClientId is null) { errors.Add("Empty client_id."); }
        else
        {
            var client = await _dbc.Clients.Include(p => p.RedirectionEndpoints).FirstOrDefaultAsync(p => p.Guid == request.ClientId,cancellationToken);
        
            if (client is null) { errors.Add("Unknown client_id"); }
            else
            {
                var endpoint = client.RedirectionEndpoints.FirstOrDefault(p => p.Uri == request.RedirectUri);
        
                if(endpoint is null) { errors.Add("Unknown redirect_uri"); }
            }
        }

        return new ValidationResult()
        {
            IsValid = errors.Count == 0,
            Errors = errors
        };
    }
}