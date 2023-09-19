namespace Identity.Application.Auth.GetJwks;

public record Jwks
{
    public required ICollection<Key> Keys { get; init; }
};