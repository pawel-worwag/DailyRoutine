namespace Identity.Application.Users.GetUsers;

public record User
{
    public required Guid Guid { get; init; }
    public required string NormalizedEmailAddress { get; init; }
    public required EmailStatus EmailStatus { get; init; }
    public required ICollection<Role> Roles { get; init; } 
    public required int RecoveryTokensCount { get; init; }
};