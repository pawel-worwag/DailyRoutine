using Identity.Application.Common.Options;
using Identity.Shared.Commands.Auth.OpenIdConfiguration;
using MediatR;
using Microsoft.Extensions.Options;

namespace Identity.Application.Auth.OpenIdConfigurationRequest;

public class OpenIdConfigurationRequest : IRequest<OpenIdConfigurationResponse>
{
    
}

public class OpenIdConfigurationRequestHandler : 
        IRequestHandler<OpenIdConfigurationRequest, OpenIdConfigurationResponse>
{
    private readonly JwtOptions _options;

    public OpenIdConfigurationRequestHandler(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public Task<OpenIdConfigurationResponse> Handle(OpenIdConfigurationRequest request, CancellationToken cancellationToken)
    {
        var response = new OpenIdConfigurationResponse();
        response.Issuer = _options.Issuer;
        response.ScopesSupported ??= new List<string>();
        response.ScopesSupported.Add("openid");
        response.ScopesSupported.Add("profile");
        response.ScopesSupported.Add("email");
        response.ScopesSupported.Add("daily_routine");
        //response.ResponseTypesSupported.Add("code");
        //response.ResponseTypesSupported.Add("id_token");
        response.ResponseTypesSupported.Add("token id_token");
        response.SubjectTypesSupported.Add("public");
        response.IdTokenSigningAlgValuesSupported.Add("RS256");
        response.JwksUri = _options.JwksUrl;
        response.TokenEndpoint = _options.TokenEndpoint;
        response.AuthorizationEndpoint = _options.AuthorizationEndpoint;
        return Task.FromResult(response);
    }
}