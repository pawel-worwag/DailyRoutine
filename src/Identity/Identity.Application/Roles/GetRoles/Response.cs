namespace Identity.Application.Roles.GetRoles;

public record Response
{
    public required ICollection<Role> Roles { get; init; } = new List<Role>();
};