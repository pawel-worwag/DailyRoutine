using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FluentValidation;
using Identity.Domain.Entities;
using Identity.Shared.Commands.Auth.Tokens;
using Identity.Shared.Common;
using Identity.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Configuration;
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

    public AccessTokenRequestHandler(UserManager<User> userManager)
    {
        this._userManager = userManager;
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
            (!string.IsNullOrWhiteSpace(scopesString))?(new()):(scopesString.Split(' ').ToList());
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
            (!string.IsNullOrWhiteSpace(scopesString))?(new()):(scopesString.Split(' ').ToList());
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
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Olab0gaKyrielejson123"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: "Issuer",
            audience: "Audience",
            claims: claims,
            expires: DateTime.UtcNow.AddSeconds(3600),
            signingCredentials: credentials
        );
        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
}