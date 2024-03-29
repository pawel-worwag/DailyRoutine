using System.Net;
using DailyRoutine.Shared.Abstractions.Exceptions;

namespace Identity.Domain.Entities;

public record PasswordRecoveryToken
{
    public string Token { get; set; }
    private int UserId { get; set; }
    public User? User { get; set; }
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
            throw new DomainException(HttpStatusCode.InternalServerError, "date_error",
                "Token 'ValidAfter' property must be before 'ValidBefore' property.");
        }
        User = subject;
        ValidAfter = validAfter;
        ValidBefore = validBefore;
    }
}