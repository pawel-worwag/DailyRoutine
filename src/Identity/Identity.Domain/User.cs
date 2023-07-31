using System.ComponentModel.DataAnnotations.Schema;
using Identity.Domain.ValueObjects;

namespace Identity.Domain;

public class User
{
    public int Id { get; private set; }
    public Guid Guid { get; private set; } = Guid.NewGuid();
    public NormalizedEmailAddress NormalizedEmail { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PasswordHash { get; set; }

    public HashSet<Role> Roles { get; private set; } = new HashSet<Role>();
}