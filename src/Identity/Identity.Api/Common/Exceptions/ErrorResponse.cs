using System.Text.Json.Serialization;

namespace Identity.Api.Common.Exceptions;

/// <summary>
/// 
/// </summary>
public record ErrorResponse
{
    /// <summary>
    /// An error code.
    /// </summary>
    [JsonPropertyName("error")]
    public required string Error { get; init; } = string.Empty;
    
    /// <summary>
    /// Optional text providing additional information about the error that occurred.
    /// </summary>
    [JsonPropertyName("error_description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; init; } = null;
    
    /// <summary>
    /// Optional URI for a web page with information about the error that occurred.
    /// </summary>
    [JsonPropertyName("error_uri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ErrorUri { get; init; } = null;

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("validation_errors")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<string>? ValidationErrors { get; init; } = null;
}