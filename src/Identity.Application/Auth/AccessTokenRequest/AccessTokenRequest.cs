using Identity.Shared.Commands.Auth.Tokens;
using MediatR;

namespace Identity.Application.Auth.AccessTokenRequest;

public class AccessTokenRequest : IRequest<TokenResponse>
{
    
}

public class AccessTokenRequestHandler : IRequestHandler<AccessTokenRequest,TokenResponse>
{
    public Task<TokenResponse> Handle(AccessTokenRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}