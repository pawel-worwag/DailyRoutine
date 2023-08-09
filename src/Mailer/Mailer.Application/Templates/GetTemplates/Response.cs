using System.Text.Json.Serialization;

namespace Mailer.Application.Templates.GetTemplates;

public record Response
{
    [JsonPropertyName("templates")]
    public required ICollection<TemplateListItem> Templates { get; init; } = default!;
};