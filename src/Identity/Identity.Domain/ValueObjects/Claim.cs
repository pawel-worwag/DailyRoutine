namespace Identity.Domain.ValueObjects;

public record Claim
{
    public string Type { get; set; }
    public string Value { get; set; }

    public Claim(string type, string value)
    {
        Type = type;
        Value = value;
    }
}