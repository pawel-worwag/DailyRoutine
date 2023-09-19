using System.Security.Cryptography.X509Certificates;
using Identity.Application.Common.Options;
using MediatR;
using Microsoft.Extensions.Options;

namespace Identity.Application.Auth.GetJwks;

public record GetJwksRequest() : IRequest<Jwks>;

internal class GetJwksHandler : IRequestHandler<GetJwksRequest, Jwks>
{
    private readonly JwksOptions _jwks;

    public GetJwksHandler(IOptions<JwksOptions> jwks)
    {
        _jwks = jwks.Value;
    }

    public async Task<Jwks> Handle(GetJwksRequest request, CancellationToken cancellationToken)
    {
        var keys = new List<Key>();
        foreach (var file in _jwks.Keys)
        {
            var c = file.KeyPassword is null
                ? new X509Certificate2(file.KeyFile)
                : new X509Certificate2(file.KeyFile, file.KeyPassword);
            if (c.HasPrivateKey)
            {
                var key = c.GetRSAPrivateKey();
                if (key is not null)
                {
                    var p = key.ExportParameters(false);
                    keys.Add(new Key()
                    {
                        Kty = key.SignatureAlgorithm,
                        E = (p.Exponent is null)?"":Convert.ToBase64String(p.Exponent)!,
                        Kid = file.Kid,
                        Alg = c.SignatureAlgorithm.FriendlyName!,
                        N = (p.Modulus is null )?"":Convert.ToBase64String(p.Modulus)!,
                        X5t = c.Thumbprint,
                        X5c = new List<string>(){c.Thumbprint},
                        Use = "sig"
                    });
                }
            }
        }

        await Task.CompletedTask;
        return new Jwks{Keys = keys};
    }
}