using System.Text.Json.Serialization;

namespace Identity.Application.Roles.GetRoles;

public record Response
{
    [JsonPropertyName("roles")]
    public required ICollection<Role> Roles { get; init; } = new List<Role>();
};