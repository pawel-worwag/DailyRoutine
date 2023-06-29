using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Auth.Users.VerifyCredentials;

public record VerifyCredentialsRequest : IRequest<CredentialsVerifyResult>
{
    public required string Email { get; init; } = string.Empty;
    public required string Password { get; init; } = string.Empty;
}

internal class Handler : IRequestHandler<VerifyCredentialsRequest, CredentialsVerifyResult>
{
    private readonly UserManager<Domain.Entities.User> _userManager;

    public Handler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CredentialsVerifyResult> Handle(VerifyCredentialsRequest request, CancellationToken cancellationToken)
    {
        var user =  await _userManager.Users.Where(p => p.NormalizedEmail == request.Email.ToUpper())
            .FirstOrDefaultAsync(cancellationToken);
        if (user is null)
        {
            return new CredentialsVerifyResult()
            {
                IsValid = false,
                Error = "Bad email or password."
            };
        }

        if (_userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) !=
            PasswordVerificationResult.Success)
        {
            return new CredentialsVerifyResult()
            {
                IsValid = false,
                Error = "Bad email or password."
            };
        }

        return new CredentialsVerifyResult();
    }
}