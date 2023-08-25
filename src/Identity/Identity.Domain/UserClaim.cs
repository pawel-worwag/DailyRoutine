namespace Identity.Domain;

public class UserClaim
{
    public int Id { get; private set; }
    public User User { get; private set; } = null!;
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}