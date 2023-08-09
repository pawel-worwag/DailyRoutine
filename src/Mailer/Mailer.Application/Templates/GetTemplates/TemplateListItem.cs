using System.Text.Json.Serialization;

namespace Mailer.Application.Templates.GetTemplates;

public record TemplateListItem
{
    [JsonPropertyName("email-type")]
    public required string Type { get; init; }
    [JsonPropertyName("email-language")]
    public required string Language { get; init; }
    [JsonPropertyName("template")] public Template? Template { get; init; } = null;
};