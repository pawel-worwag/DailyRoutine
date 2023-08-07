using System.Text.Json.Serialization;

namespace Mailer.Application.Attachments.GetAttachments;

public record GetAttachmentsResponse
{
    [JsonPropertyName("attachments")]
    public required ICollection<Attachment> Attachments { get; init; } = default!;
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}