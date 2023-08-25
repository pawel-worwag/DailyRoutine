namespace Identity.Domain.ValueObjects;

public record NormalizedName
{
    public string Value { get; }

    public NormalizedName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("NormalizedName cannot be null, empty or whitespace.");
        }
        Value = value.ToUpperInvariant();
    }
}