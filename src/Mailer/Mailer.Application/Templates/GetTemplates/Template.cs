using System.Text.Json.Serialization;

namespace Mailer.Application.Templates.GetTemplates;

public record Template
{
    [JsonPropertyName("guid")]
    public required Guid Guid { get; init; }
    [JsonPropertyName("subject")]
    public required string Subject { get; init; }
    [JsonPropertyName("references-count")]
    public required int ReferencesCount { get; init; }
};