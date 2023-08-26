namespace Identity.Application.Users.GetUserDetails;

public record Role
{
    public required string NormalizedName { get; init; }
}