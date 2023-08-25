namespace Mailer.Application.Templates.GetTemplateAttachments;

public record Response
{
    public required ICollection<Attachment> Attachments { get; init; }
};