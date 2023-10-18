using Identity.Application.Common.Interfaces;
using Identity.Domain;
using Identity.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Auth.GetAuthorization;

public record GetAuthorizationRequest : IRequest<AuthorizationResult>
{
    // token ot code
    public string? ResponseType { get; init; }
    public Guid? ClientId { get; init; } = null;
    public string? RedirectUri { get; init; } = null;
    public string? Scope { get; init; } = null;
    public string? State { get; init; } = null;
    public string UserName { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}

internal class GetAuthorizationHandler : IRequestHandler<GetAuthorizationRequest, AuthorizationResult>
{
    private readonly IIdentityDbContext _dbc;    
    private readonly IPasswordHasher<Domain.User> _passwordHasher;

    public GetAuthorizationHandler(IIdentityDbContext dbc, IPasswordHasher<User> passwordHasher)
    {
        _dbc = dbc;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthorizationResult> Handle(GetAuthorizationRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<string>();
        string RedirectUri = "";

        if (string.IsNullOrWhiteSpace(request.UserName))
        {
            errors.Add("Login is empty");
        }
        else if (string.IsNullOrWhiteSpace(request.Password))
        {
            errors.Add("Password is empty");
        }
        else if (request.UserName.Count(x => x == '@') != 1)
        {
            errors.Add("Unknown user name or bad password");
        }
        else
        {
            var user = await _dbc.Users
                .Include(p => p.Roles).ThenInclude(p => p.Claims)
                .Include("UserClaims")
                .Include("EmailConfirmationToken")
                .FirstOrDefaultAsync(p => p.NormalizedEmail == new NormalizedEmailAddress(request.UserName),
                    cancellationToken);
            if (user is null)
            {
                errors.Add("Unknown user name or bad password");
            }
            else
            {
                if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
                {
                    errors.Add("Unknown user name or bad password");
                }
                else
                {
                    //prepare toknes
                    var accessToken = PrepareAccessToken(user, request.Scope.Split(" ").ToList());
                }
            }
        }

        return new AuthorizationResult()
        {
            IsValid = errors.Count == 0,
            Errors = errors,
            RedirectUri = "snusuw"
        };
    }

    private string PrepareAccessToken(User user, ICollection<string> scopes)
    {
        
        return "";
    }
}