using System.Text.Json.Serialization;

namespace Identity.Application.Users.GetUsers;

public record User
{
    [JsonPropertyName("guid")]
    public required Guid Guid { get; init; }
    [JsonPropertyName("normalized-email-address")]
    public required string NormalizedEmailAddress { get; init; }
    [JsonPropertyName("email-status")]
    public required EmailStatus EmailStatus { get; init; }
    [JsonPropertyName("roles")]
    public required ICollection<Role> Roles { get; init; } 
    [JsonPropertyName("recovery-tokens-count")]
    public required int RecoveryTokensCount { get; init; }
};