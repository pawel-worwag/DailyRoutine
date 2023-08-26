using System.Text.Json.Serialization;

namespace Identity.Api.Models.Users;

/// <summary>
/// 
/// </summary>
public record AddNewUserDto
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("normalized-email")]
    public required string NormalizedEmail { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("roles")]
    public required ICollection<string> Roles { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("personal-claims")]
    public required ICollection<Claim> PersonalClaims { get; init; }
 
}
