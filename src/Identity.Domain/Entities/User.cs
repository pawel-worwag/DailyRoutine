namespace Identity.Domain.Entities;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<int>
{
    public string DisplayName { get; set; } = string.Empty;
    public Guid Guid { get; set; } = Guid.NewGuid();
}