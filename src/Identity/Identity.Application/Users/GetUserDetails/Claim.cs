namespace Identity.Application.Users.GetUserDetails;

public record Claim
{
    public required string Type { get; init; }
    public required string Value { get; init; }
};