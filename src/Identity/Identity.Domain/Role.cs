using Identity.Domain.ValueObjects;

namespace Identity.Domain;

public class Role
{
    public int Id { get; private set; }
    public NormalizedName NormalizedName { get; set; }
}