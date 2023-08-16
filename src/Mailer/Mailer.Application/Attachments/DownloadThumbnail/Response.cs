namespace Mailer.Application.Attachments.DownloadThumbnail;

public record Response
{
    public required string Name { get; init; }
    public required string FileTempPath { get; set; }
};