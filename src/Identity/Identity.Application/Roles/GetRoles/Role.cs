using System.Text.Json.Serialization;

namespace Identity.Application.Roles.GetRoles;

public record Role
{
    [JsonPropertyName("normalized-name")]
    public required string NormalizedName { get; init; }
    [JsonPropertyName("claims")]
    public required ICollection<Claim> Claims { get; init; }
};