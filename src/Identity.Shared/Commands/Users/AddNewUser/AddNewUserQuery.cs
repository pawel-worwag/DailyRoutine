using Microsoft.AspNetCore.Mvc;

namespace Identity.Shared.Commands.Users.AddNewUser;

public class AddNewUserQuery
{
    public string DisplayName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; } = false;
    public string? Password { get; set; } = null;
    public ICollection<string> Roles { get; set; } = new List<string>();
}