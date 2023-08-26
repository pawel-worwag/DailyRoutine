using System.Text.Json.Serialization;

namespace Identity.Application.Users.GetUserDetails;

public record Claim
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }
    [JsonPropertyName("value")]
    public required string Value { get; init; }
};