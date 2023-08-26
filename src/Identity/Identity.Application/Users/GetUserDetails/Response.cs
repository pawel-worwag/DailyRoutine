namespace Identity.Application.Users.GetUserDetails;

public record Response
{
    public required Guid Guid { get; init; }
    public required string NormalizedEmailAddress { get; init; }
    public required EmailStatus EmailStatus { get; init; }
    public required ICollection<Role> Roles { get; init; }
    public required ICollection<RecoveryToken> RecoveryTokens { get; init; }
    public required ICollection<Claim> PersonalClaims { get; init; }
    
};