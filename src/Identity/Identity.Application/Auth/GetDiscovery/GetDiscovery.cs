using MediatR;
using Microsoft.Extensions.Configuration;

namespace Identity.Application.Auth.GetDiscovery;

public record GetDiscoveryRequest : IRequest<OpenIdConfiguration>
{
    
}

internal class GetDiscoveryHandler : IRequestHandler<GetDiscoveryRequest,OpenIdConfiguration>
{
    private IConfiguration _conf;

    public GetDiscoveryHandler(IConfiguration conf)
    {
        _conf = conf;
    }

    public async Task<OpenIdConfiguration> Handle(GetDiscoveryRequest request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new OpenIdConfiguration()
        {
            Issuer = _conf.GetValue<string>("Auth:Discovery:Issuer","")!,
            AuthorizationEndpoint = _conf.GetValue<string>("Auth:Discovery:AuthorizationEndpoint","")!,
            JwksUri = _conf.GetValue<string>("Auth:Discovery:JwksUri","")!,
            IdTokenSigningAlgValuesSupported = _conf.GetSection("Auth:Discovery:IdTokenSigningAlgValuesSupported").Get<string[]>()!,
            ScopesSupported = _conf.GetSection("Auth:Discovery:ScopesSupported").Get<string[]>()!,
            TokenEndpoint = _conf.GetValue<string>("Auth:Discovery:TokenEndpoint","")!,
            ResponseTypesSupported = _conf.GetSection("Auth:Discovery:ResponseTypesSupported").Get<string[]>()!,
            SubjectTypesSupported = _conf.GetSection("Auth:Discovery:SubjectTypesSupported").Get<string[]>()!,
            ClaimsSupported = _conf.GetSection("Auth:Discovery:ClaimsSupported").Get<string[]>()!
        };
    }
}