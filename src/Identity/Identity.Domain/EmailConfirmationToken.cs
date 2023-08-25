using System.Net;
using DailyRoutine.Shared.Abstractions.Exceptions;

namespace Identity.Domain;

public record EmailConfirmationToken
{
    public int UserId { get; private set; }
    public DateTime ValidBefore { get; private set; }
    public User User { get; private set; } = null!;
    public string Token { get; private set; }

    private EmailConfirmationToken()
    {
        var random = new Random();
        Token = random.Next(0, 99999).ToString("D5");
    }
    
    public EmailConfirmationToken(User subject, DateTime validBefore) : this()
    {
        User = subject;
        ValidBefore = validBefore;
    }
}