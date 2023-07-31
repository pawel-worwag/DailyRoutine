namespace Identity.Domain;

public class RoleClaim
{
    public int Id { get; private set; }
    public Role Role { get; private set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}