using System.Text.Json.Serialization;

namespace Mailer.Application.Templates.GetDetails;

public record Attachment
{
    [JsonPropertyName("guid")]
    public required Guid Guid { get; init; }
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    [JsonPropertyName("media-type")]
    public required string MediaType { get; init; }
    [JsonPropertyName("description")]
    public required string Description { get; init; }
    [JsonPropertyName("inline")]
    public required bool InLine { get; init; }
}