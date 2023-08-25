namespace Identity.Application.Roles.GetRoles;

public record Role
{
    public required string NormalizedName { get; init; }
    public required ICollection<Claim> Claims { get; init; }
};