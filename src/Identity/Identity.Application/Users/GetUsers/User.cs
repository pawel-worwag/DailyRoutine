namespace Identity.Application.Users.GetUsers;

public record User
{
    public required Guid Guid { get; init; }
    public required string NormalizedEmailAddress { get; init; }
    public required bool EmailConfirmed { get; init; }
};