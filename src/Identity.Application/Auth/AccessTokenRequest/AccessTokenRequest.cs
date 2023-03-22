using Identity.Shared.Commands.Auth.Tokens;
using MediatR;

namespace Identity.Application.Auth.AccessTokenRequest;

public class AccessTokenRequest : IRequest<TokenResponse>
{
    public string? Username { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
    public string? Scope { get; set; } = string.Empty;
}

public class AccessTokenRequestHandler : IRequestHandler<AccessTokenRequest,TokenResponse>
{
    public Task<TokenResponse> Handle(AccessTokenRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}