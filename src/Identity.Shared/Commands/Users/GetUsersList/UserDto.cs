namespace Identity.Shared.Commands.Users.GetUsersList;

public class UserDto
{
    public string Email { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public int AccessFailedCount { get; set; }
    public DateTimeOffset? LockoutEnd { get; set; }
    public ICollection<string> Roles { get; set; } = new List<string>();
}