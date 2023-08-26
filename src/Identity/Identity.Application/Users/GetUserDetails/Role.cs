using System.Text.Json.Serialization;

namespace Identity.Application.Users.GetUserDetails;

public record Role
{
    [JsonPropertyName("normalized-name")]
    public required string NormalizedName { get; init; }
}