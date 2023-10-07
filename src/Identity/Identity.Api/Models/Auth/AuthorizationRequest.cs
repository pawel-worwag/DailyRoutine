using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Identity.Api.Models.Auth;

/// <summary>
/// 
/// </summary>
public record AuthorizationRequest
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("response_type")]
    [Required]
    public required string ResponseType { get; init; }
    
    /// <summary>
    /// The client identifier
    /// </summary>
    [JsonPropertyName("client_id")]
    [Required]
    public required string ClientId { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; init; } = null;
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("scope")]
    public string? Scope { get; init; } = null;
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; init; } = null;
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("nonce")]
    public string? Nonce { get; init; } = null;
    
}