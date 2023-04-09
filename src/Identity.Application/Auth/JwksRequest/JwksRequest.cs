using System.Security.Cryptography.X509Certificates;
using Identity.Application.Common.Options;
using Identity.Shared.Commands.Auth.Jwks;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Application.Auth.JwksRequest;

public class JwksRequest : IRequest<JwksResponse>
{
    
}

public class JwksRequestHandler : IRequestHandler<JwksRequest, JwksResponse>
{
    private readonly JwksOptions _options;

    public JwksRequestHandler(IOptions<JwksOptions> options)
    {
        _options = options.Value;
    }

    public Task<JwksResponse> Handle(JwksRequest request, CancellationToken cancellationToken)
    {
        var result = new JwksResponse();
        foreach (var key in _options.Keys)
        {
            result.Keys.Add(PrepareKeyEntry(key));
        }
        return Task.FromResult(result);
    }

    private KeyEntry PrepareKeyEntry(JwkOptions options)
    {
        X509Certificate2 cert = options.KeyPassword is null ? new X509Certificate2(options.KeyFile) : new X509Certificate2(options.KeyFile, options.KeyPassword);
        
        var key = new X509SecurityKey(cert);
        var jwk = JsonWebKeyConverter.ConvertFromX509SecurityKey(key, true);
        
        var result = new KeyEntry()
        {
            Kid = jwk.Kid,
            Alg = jwk.Alg ?? "RS256",
            Kty = jwk.Kty,
            N = jwk.N,
            E = jwk.E
        };
        return result;
    }
}