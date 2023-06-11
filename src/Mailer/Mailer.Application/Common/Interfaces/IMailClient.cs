using System.Net.Mail;

namespace Mailer.Application.Common.Interfaces;

public record MailData
{
    public required List<string> To { get; init; } = new List<string>();
    public required string Subject { get; init; }
    public required string? Body { get; init; }

    public ICollection<MailaDataAttachment> Attachments { get; init; } = new List<MailaDataAttachment>();
}

public record MailaDataAttachment
{
    public bool Inline { get; set; } = false;
    public string? FileName { get; init; } = null;
    public string? Cid { get; init; } = null;
    public byte[] Data { get; init; } = Array.Empty<byte>();
    public string MimeType { get; init; } = String.Empty;
    
}

public interface IMailClient
{
    Task SendAsync(MailData mail, CancellationToken cancellationToken);
}