using System.Text.Json.Serialization;

namespace Mailer.Application.Attachments.GetAttachments;

public record Response
{
    [JsonPropertyName("attachments")]
    public required ICollection<Attachment> Attachments { get; init; } = default!;
    [JsonPropertyName("all-count")]
    public required int AllCount { get; init; }
}