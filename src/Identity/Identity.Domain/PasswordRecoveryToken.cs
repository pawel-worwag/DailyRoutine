using System.Net;
using Identity.Domain.Common.Exceptions;

namespace Identity.Domain.Entities;

public record PasswordRecoveryToken
{
    public string Token { get; private set; }
    public int UserId { get;  set; }
    public User User { get; set; } = default!;
    public DateTime ValidAfter { get; set; } = DateTime.UtcNow;
    public DateTime ValidBefore { get; set; }  = DateTime.UtcNow;

    public PasswordRecoveryToken()
    {
        Token = Guid.NewGuid().ToString("N");
    }
    
    public PasswordRecoveryToken(User subject, DateTime validAfter, DateTime validBefore) : this()
    {
        if (validAfter >= validBefore)
        {
            throw new BadDateException("Token 'ValidAfter' property must be before 'ValidBefore' property.");
        }
        ValidAfter = validAfter;
        ValidBefore = validBefore;
    }
}