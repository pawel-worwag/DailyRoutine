using Identity.Domain.ValueObjects;

namespace Identity.Domain;

public class Role
{
    public int Id { get; private set; }
    public NormalizedName NormalizedName { get; set; }
    public HashSet<User> Users { get; private set; } = new HashSet<User>();
}