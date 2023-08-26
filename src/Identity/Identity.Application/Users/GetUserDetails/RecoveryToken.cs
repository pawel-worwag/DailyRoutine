namespace Identity.Application.Users.GetUserDetails;

public record RecoveryToken
{
    public required DateTime ValidAfter { get; init; }
    public required DateTime ValidBefore { get; init; }
};