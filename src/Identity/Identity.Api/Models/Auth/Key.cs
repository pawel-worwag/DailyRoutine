namespace Identity.Api.Models.Auth;

public record Key
{
    public required string Alg { get; init; }
    public required string Kty { get; init; }
    public required string Use { get; init; }
    public required ICollection<string> X5c { get; init; }
    public required string N { get; init; }
    public required string E { get; init; }
    public required string Kid { get; init; }
    public required string X5t { get; init; }
};