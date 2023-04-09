namespace Identity.Shared.Commands.Auth.Jwks;

public class JwksResponse
{
    public ICollection<KeyEntry> Keys { get; set; } = new List<KeyEntry>();
}