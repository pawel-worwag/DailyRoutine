using System.Net.Mail;

namespace Mailer.Application.Common.Interfaces;

public record MailData
{
    public required List<string> To { get; init; } = new List<string>();
    public required string Subject { get; init; }
    public required string? Body { get; init; }
}

public interface IMailClient
{
    Task SendAsync(MailData mail, CancellationToken cancellationToken);
}