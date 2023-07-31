using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Identity.Domain.ValueObjects;
using Claim = Identity.Domain.ValueObjects.Claim;

namespace Identity.Domain;

public class User
{
    public int Id { get; private set; }
    public Guid Guid { get; private set; } = Guid.NewGuid();
    public NormalizedEmailAddress NormalizedEmail { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PasswordHash { get; set; }
    public HashSet<Role> Roles { get; private set; } = new HashSet<Role>();
    protected ICollection<UserClaim> UserClaims { get; private set; } = new List<UserClaim>();
    [NotMapped]
    public IReadOnlyCollection<Claim> Claims
    {
        get
        {
            var claims = new List<Claim>();
            foreach (var c in UserClaims)
            {
                claims.Add(new Claim(c.ClaimType,c.ClaimValue));
            }

            foreach (var c in Roles.SelectMany(p=>p.Claims))
            {
                claims.Add(new Claim(c.ClaimType,c.ClaimValue));
            }
            return claims;
        }
    }
}