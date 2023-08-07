using System.Text.Json.Serialization;

namespace Mailer.Application.Attachments.GetAttachments;

public record Attachment
{
    [JsonPropertyName("guid")]
    public required Guid Guid { get; init; }
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    [JsonPropertyName("media-type")]
    public string MediaType { get; init; } = default!;
    [JsonPropertyName("description")]
    public string Description { get; init; } = default!;
    [JsonPropertyName("inline")]
    public bool Inline { get; init; }
    [JsonPropertyName("references-count")]
    public int ReferencesCount { get; init; }
};