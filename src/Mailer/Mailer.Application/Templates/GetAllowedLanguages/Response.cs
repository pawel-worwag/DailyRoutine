using System.Text.Json.Serialization;

namespace Mailer.Application.Templates.GetAllowedLanguages;

public record Response
{
    [JsonPropertyName("languages")]
    public required IReadOnlyCollection<string> Languages { get; init; } = default!;
    [JsonPropertyName("all-count")]
    public required int AllCount { get; init; }
};