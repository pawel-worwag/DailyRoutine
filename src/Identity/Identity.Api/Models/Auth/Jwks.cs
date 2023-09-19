namespace Identity.Api.Models.Auth;

public record Jwks
{
    public required ICollection<Key> Keys { get; init; }
};