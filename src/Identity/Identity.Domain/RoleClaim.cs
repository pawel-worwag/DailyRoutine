namespace Identity.Domain;

public class RoleClaim
{
    public int Id { get; private set; }
    public Role Role { get; private set; } = default!;
    public string ClaimType { get; set; } = string.Empty;
    public string ClaimValue { get; set; } = string.Empty;
}