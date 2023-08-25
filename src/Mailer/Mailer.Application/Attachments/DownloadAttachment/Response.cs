namespace Mailer.Application.Attachments.DownloadAttachment;

public record Response
{
    public required string Name { get; init; }
    public required string MimeType { get; set; }
    public required string FileTempPath { get; set; }
};