using System.Text.Json.Serialization;

namespace Identity.Application.Users.GetUserDetails;

public record Response
{
    [JsonPropertyName("guid")]
    public required Guid Guid { get; init; }
    [JsonPropertyName("normalized-email-address")]
    public required string NormalizedEmailAddress { get; init; }
    [JsonPropertyName("email-status")]
    public required EmailStatus EmailStatus { get; init; }
    [JsonPropertyName("roles")]
    public required ICollection<Role> Roles { get; init; }
    [JsonPropertyName("recovery-tokens")]
    public required ICollection<RecoveryToken> RecoveryTokens { get; init; }
    [JsonPropertyName("personal-claims")]
    public required ICollection<Claim> PersonalClaims { get; init; }
    [JsonPropertyName("time-zone")]
    public required string TimeZone { get; init; }
    [JsonPropertyName("culture")]
    public required string Culture { get; init; }
    
    
};