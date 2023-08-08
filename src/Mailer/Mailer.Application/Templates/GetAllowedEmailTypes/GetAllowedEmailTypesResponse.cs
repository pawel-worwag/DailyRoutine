using System.Text.Json.Serialization;

namespace Mailer.Application.Templates.GetAllowedEmailTypes;

public record GetAllowedEmailTypesResponse
{
    [JsonPropertyName("email-types")]
    public required IReadOnlyCollection<string> EmailTypes { get; init; } = default!;
    [JsonPropertyName("all-count")]
    public required int AllCount { get; init; }
};