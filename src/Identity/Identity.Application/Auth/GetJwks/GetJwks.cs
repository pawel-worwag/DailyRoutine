using System.Security.Cryptography.X509Certificates;
using Identity.Application.Common.Options;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Identity.Application.Auth.GetJwks;

public record GetJwksRequest() : IRequest<Jwks>;

internal class GetJwksHandler : IRequestHandler<GetJwksRequest, Jwks>
{
    private readonly JwksOptions _jwks;
    private readonly ILogger _logger;

    public GetJwksHandler(IOptions<JwksOptions> jwks, ILogger<GetJwksHandler> logger)
    {
        _logger = logger;
        _jwks = jwks.Value;
    }

    public async Task<Jwks> Handle(GetJwksRequest request, CancellationToken cancellationToken)
    {
        var keys = new List<Key>();
        foreach (var file in _jwks.Keys)
        {
            if (!File.Exists(file.KeyFile))
            {
                _logger.LogWarning("File '{file}' not exists.", file.KeyFile);
                continue;
            }

            try
            {
                var c = file.KeyPassword is null
                    ? new X509Certificate2(file.KeyFile)
                    : new X509Certificate2(file.KeyFile, file.KeyPassword);

                var n = DateTime.UtcNow;
                if ((c.NotAfter < n) || (c.NotBefore > n)) continue;

                if (!c.HasPrivateKey) continue;

                var key = c.GetRSAPrivateKey();
                if (key is null) continue;

                var p = key.ExportParameters(false);
                keys.Add(new Key()
                {
                    Kty = key.SignatureAlgorithm,
                    E = (p.Exponent is null) ? "" : Convert.ToBase64String(p.Exponent)!,
                    Kid = file.Kid,
                    Alg = c.SignatureAlgorithm.FriendlyName!,
                    N = (p.Modulus is null) ? "" : Convert.ToBase64String(p.Modulus)!,
                    X5t = c.Thumbprint,
                    X5c = new List<string>() { c.Thumbprint },
                    Use = "sig"
                });
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Error when opening file '{file}'. {message}", file.KeyFile,ex.Message);
            }
        }

        await Task.CompletedTask;
        return new Jwks { Keys = keys };
    }
}