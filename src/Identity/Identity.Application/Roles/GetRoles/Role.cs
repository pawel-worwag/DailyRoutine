namespace Identity.Application.Roles.GetRoles;

public record Role
{
    public required string NormalizedName { get; init; }
};