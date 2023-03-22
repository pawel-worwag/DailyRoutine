using FluentValidation;
using Identity.Shared.Commands.Auth.Tokens;
using Identity.Shared.Common;
using MediatR;

namespace Identity.Application.Auth.AccessTokenRequest;

public class AccessTokenRequest : IRequest<TokenResponse>
{
    public string? Username { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
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
    public Task<TokenResponse> Handle(AccessTokenRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}