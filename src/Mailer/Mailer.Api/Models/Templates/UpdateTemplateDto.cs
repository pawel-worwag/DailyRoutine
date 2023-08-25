using System.Text.Json.Serialization;

namespace Mailer.Api.Models.Templates;

/// <summary>
/// 
/// </summary>
public record UpdateTemplateDto
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("subject")]
    public required string Subject { get; init; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("body-encoded")]
    public required string BodyEncoded { get; init; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("attachment-ids")]
    public required ICollection<Guid> Attachments { get; init; } 
};