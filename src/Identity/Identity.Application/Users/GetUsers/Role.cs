using System.Text.Json.Serialization;

namespace Identity.Application.Users.GetUsers;

public record Role
{
    [JsonPropertyName("normalized-name")]
    public required string NormalizedName { get; init; }
};