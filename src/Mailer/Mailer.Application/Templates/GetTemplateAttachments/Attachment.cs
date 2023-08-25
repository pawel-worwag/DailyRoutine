using System.Text.Json.Serialization;

namespace Mailer.Application.Templates.GetTemplateAttachments;

public record Attachment
{
    [JsonPropertyName("guid")]
    public required Guid Guid { get; init; }
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    [JsonPropertyName("media-type")]
    public required string MediaType { get; init; } = default!;
    [JsonPropertyName("description")]
    public string Description { get; init; } = default!;
    [JsonPropertyName("inline")]
    public required bool Inline { get; init; }
};