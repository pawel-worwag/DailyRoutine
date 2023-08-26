using System.Text.Json.Serialization;

namespace Identity.Application.Users.GetUserDetails;

public record RecoveryToken
{
    [JsonPropertyName("valid-after")]
    public required DateTime ValidAfter { get; init; }
    [JsonPropertyName("valid-before")]
    public required DateTime ValidBefore { get; init; }
};