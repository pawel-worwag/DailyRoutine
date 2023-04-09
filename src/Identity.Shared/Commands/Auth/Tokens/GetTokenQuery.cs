using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Shared.Commands.Auth.Tokens;

public class GetTokenQuery
{
    [JsonPropertyName("grant_type")]
    [FromForm(Name = "grant_type")]
    public string? GrantType { get; set; } = null;
    
    [JsonPropertyName("code")]
    [FromForm(Name = "code")]
    public string? Code { get; set; } = null;
    [JsonPropertyName("redirect_uri")]
    [FromForm(Name = "redirect_uri")]
    public string? RedirectUri { get; set; } = null;
    [JsonPropertyName("client_id")]
    [FromForm(Name = "client_id")]
    public string? ClientId { get; set; } = null;
    
    [JsonPropertyName("username")]
    [FromForm(Name = "username")]
    public string? Username { get; set; } = null;
    [JsonPropertyName("password")]
    [FromForm(Name = "password")]
    public string? Password { get; set; } = null;
    [JsonPropertyName("scope")]
    [FromForm(Name = "scope")]
    public string? Scope { get; set; } = null;
    
    [JsonPropertyName("refresh_token")]
    [FromForm(Name = "refresh_token")]
    public string? RefreshToken { get; set; } = null;
    
}

public static class GrantTypeNames
{
    /// <summary>
    /// 
    /// </summary>
    public const string AuthorizationCode = "authorization_code";
    /// <summary>
    /// 
    /// </summary>
    public const string Password = "password";
    /// <summary>
    /// 
    /// </summary>
    public const string ClientCredentials = "client_credentials";
    /// <summary>
    /// 
    /// </summary>
    public const string RefreshToken = "refresh_token";
} 