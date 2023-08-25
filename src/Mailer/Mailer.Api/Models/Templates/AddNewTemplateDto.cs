using System.Text.Json.Serialization;

namespace Mailer.Api.Models.Templates;

/// <summary>
/// 
/// </summary>
public record AddNewTemplateDto
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("language")]
    public required string Language { get; init; }
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