using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Identity.Shared.Commands.Auth.Tokens;

public class TokenResponse
{
    /// <summary>
    /// The access token.
    /// </summary>
    [JsonPropertyName("access_token")]
    [Required]
    public string AccessToken { get; set; } = String.Empty;
    /// <summary>
    /// The type of the access token, set to Bearer, DPoP or N_A.
    /// </summary>
    [JsonPropertyName("token_type")]
    [Required]
    public string TokenType { get; set; } = String.Empty;
    /// <summary>
    /// The lifetime of the access token, in seconds.
    /// </summary>
    [JsonPropertyName("expires_in")]
    [Required]
    public int ExpiresIn { get; set; } = 3600;
    /// <summary>
    /// The scope of the access token.
    /// </summary>
    [JsonPropertyName("scope")]
    [Required]
    public string Scope { get; set; } = String.Empty;
    /// <summary>
    /// Optional refresh token, which can be used to obtain new access tokens.
    /// </summary>
    [JsonPropertyName("refresh_token")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string RefreshToken { get; set; } = String.Empty;
    /// <summary>
    /// Optional OpenID Connect identity token.
    /// </summary>
    [JsonPropertyName("id_token")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string IdToken { get; set; } = String.Empty;
}