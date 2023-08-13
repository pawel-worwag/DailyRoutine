using System.Text.Json.Serialization;

namespace Mailer.Application.Attachments.GetDetails;

public record Template
{
    [JsonPropertyName("guid")] 
    public required Guid? Guid { get; init; }
    [JsonPropertyName("email-type")]
    public required string Type { get; init; }
    [JsonPropertyName("email-language")]
    public required string Language { get; init; }
}