namespace Identity.Application.Users.GetUsers;

public record Role
{
    public required string NormalizedName { get; init; }
};