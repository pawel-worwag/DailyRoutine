using System.Text.Json.Serialization;

namespace Identity.Application.Roles.GetRoles;

public record Claim
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }
    [JsonPropertyName("value")]
    public required string Value { get; init; }
};