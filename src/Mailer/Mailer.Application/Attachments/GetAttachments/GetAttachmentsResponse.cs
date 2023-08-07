using System.Text.Json.Serialization;

namespace Mailer.Application.Attachments.GetAttachments;

public record GetAttachmentsResponse
{
    [JsonPropertyName("attachments")]
    public required ICollection<Attachment> Attachments { get; init; } = default!;
    [JsonPropertyName("all-attachments-count")]
    public required int AllAttachmentsCount { get; init; }
}