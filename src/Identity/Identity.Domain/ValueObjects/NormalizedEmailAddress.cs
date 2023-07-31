namespace Identity.Domain.ValueObjects;

public record NormalizedEmailAddress
{
    public NormalizedEmailAddress(string value)
    {
        if (value.Count(x => x == '@') != 1)
        {
            throw new Exception("Invalid email address (wrong count of '@' char).");
        };
        Value = value.ToUpperInvariant();
    }
    public string Value { get; }
}