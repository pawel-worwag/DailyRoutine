using System.Text.Json.Serialization;

namespace Mailer.Api.Models.Templates;

/// <summary>
/// 
/// </summary>
public record AddNewTemplateDto
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }
    [JsonPropertyName("language")]
    public required string Language { get; init; }
    [JsonPropertyName("subject")]
    public required string Subject { get; init; }
    [JsonPropertyName("body-encoded")]
    public required string BodyEncoded { get; init; }
    [JsonPropertyName("attachment-ids")]
    public required ICollection<Guid> Attachments { get; init; } 
};