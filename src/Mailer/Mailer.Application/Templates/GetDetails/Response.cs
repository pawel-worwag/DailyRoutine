using System.Text.Json.Serialization;

namespace Mailer.Application.Templates.GetDetails;

public record Response
{
    [JsonPropertyName("guid")]
    public required Guid Guid { get; init; }
    [JsonPropertyName("type")]
    public required string Type { get; init; }
    [JsonPropertyName("language")]
    public required string Language { get; init; }
    [JsonPropertyName("subject")]
    public required string Subject { get; init; }
    [JsonPropertyName("body-encoded")]
    public required string BodyEncoded { get; init; }
    [JsonPropertyName("attachments")]
    public required ICollection<Attachment> Attachments { get; init; }
};