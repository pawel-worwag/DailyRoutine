using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using Identity.Application.Common.Options;
using Identity.Domain.Entities;
using Identity.Shared.Commands.Auth.Tokens;
using Identity.Shared.Common;
using Identity.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Identity.Application.Auth.AccessTokenRequest;

public class AccessTokenRequest : IRequest<TokenResponse>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Scope { get; set; } = string.Empty;
}

public sealed class AccessTokenRequestValidator : AbstractValidator<AccessTokenRequest>, IAuthValidator
{
    public AccessTokenRequestValidator()
    {
        RuleFor(e => e.Username).NotEmpty().WithMessage("Field 'username' cannot be empty.");
        RuleFor(e => e.Password).NotEmpty().WithMessage("Field 'password' cannot be empty.");
    }
}

public class AccessTokenRequestHandler : IRequestHandler<AccessTokenRequest,TokenResponse>
{
    
    private readonly UserManager<User> _userManager;
    private readonly JwtOptions _options;

    public AccessTokenRequestHandler(UserManager<User> userManager, IOptions<JwtOptions> options)
    {
        this._userManager = userManager;
        _options = options.Value;
    }

    public async Task<TokenResponse> Handle(AccessTokenRequest request, CancellationToken cancellationToken)
    {
        
        var user = await _userManager.FindByEmailAsync(request.Username);
        if(user is null) {throw new ProblemException(HttpStatusCode.BadGateway,"auth_failed","Invalid UserName or Password");}
        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if(!passwordValid) {throw new ProblemException(HttpStatusCode.BadGateway,"auth_failed","Invalid UserName or Password");}

        var response = new TokenResponse()
        {
            TokenType = "Bearer",
            Scope = request.Scope ?? "",
            AccessToken = await GenerateToken(await PrepareAccessClaimsAsync(user, request.Scope??"")),
            IdToken = await GenerateToken(PrepareIdClaims(user, request.Scope??"")),
            RefreshToken = GenerateRefreshToken()
        };
        
        return response;
    }

    private  string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
    
    private  IEnumerable<Claim> PrepareIdClaims(User user, string scopesString)
    {
        List<string> scopes = 
            (string.IsNullOrWhiteSpace(scopesString))?(new()):(scopesString.Split(' ').ToList());
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        if (scopes.Contains("openid"))
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserName??""));
        }
        if (scopes.Contains("email"))
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        }
        if (scopes.Contains("profile"))
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.DisplayName));
            claims.Add(new Claim("locale", "pl"));
            claims.Add(new Claim("zoneinfo", "utc"));
        }
        return claims;
    }
    
    private async Task<IEnumerable<Claim>> PrepareAccessClaimsAsync(User user, string scopesString)
    {
        List<string> scopes = 
            (string.IsNullOrWhiteSpace(scopesString))?(new()):(scopesString.Split(' ').ToList());
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        if (scopes.Contains("daily_routine"))
        {
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();
            claims.AddRange(roleClaims);
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);
        }
        return claims;
    }

    private Task<string> GenerateToken(IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddSeconds(_options.Expires),
            signingCredentials: new SigningCredentials(SelectKey(),"RS256")
        );
        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }

    private X509SecurityKey? SelectKey()
    {
        foreach (var keyItem in _options.Keys)
        {
            if (File.Exists(keyItem.KeyFile))
            {
                var certificate = keyItem.KeyPassword is null ? (new X509Certificate2(keyItem.KeyFile)):(new X509Certificate2(keyItem.KeyFile,keyItem.KeyPassword));
                var time = DateTime.Now;
                if(time <= certificate.NotAfter.AddSeconds(-_options.Expires) && time >= certificate.NotBefore && certificate.HasPrivateKey)
                {
                    return new X509SecurityKey(certificate);
                }
            }
        }
        throw new ProblemException(HttpStatusCode.InternalServerError, "key_error", "Valid key not found");
    }
}