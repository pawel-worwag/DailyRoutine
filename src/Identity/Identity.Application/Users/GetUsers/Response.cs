using System.Text.Json.Serialization;

namespace Identity.Application.Users.GetUsers;

public record Response
{
    [JsonPropertyName("users")]
    public required ICollection<User> Users { get; init; }
    [JsonPropertyName("all-count")]
    public required int AllCount { get; init; }
};