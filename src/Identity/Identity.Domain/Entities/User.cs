namespace Identity.Domain.Entities;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<int>
{
    public Guid Guid { get; set; } = Guid.NewGuid();
}