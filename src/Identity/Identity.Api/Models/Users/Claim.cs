using System.Text.Json.Serialization;

namespace Identity.Api.Models.Users;

/// <summary>
/// 
/// </summary>
public record Claim
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; init; }
}