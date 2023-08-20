using System.Text.Json.Serialization;

namespace Mailer.Api.Models.Attachments;

/// <summary>
/// 
/// </summary>
public record UpdateAttachmentMetadataDto
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("media-type")]
    public required string MediaType { get; init; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("inline")]
    public required bool Inline { get; init; }
};