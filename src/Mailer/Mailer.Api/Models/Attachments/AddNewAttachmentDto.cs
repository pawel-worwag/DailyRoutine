using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Mailer.Api.Models.Attachments;

/// <summary>
/// 
/// </summary>
public record AddNewAttachmentDto
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    [JsonPropertyName("media-type")]
    public required string MediaType { get; init; }
    [JsonPropertyName("description")]
    public required string Description { get; init; }
    [JsonPropertyName("inline")]
    public required bool Inline { get; init; }
    [JsonPropertyName("file")]
    public required IFormFile File { get; init; }
};