namespace Identity.Domain.ValueObjects;

public record Claim
{
    public string Type { get; }
    public string Value { get; }

    public Claim(string type, string value)
    {
        Type = type;
        Value = value;
    }
}