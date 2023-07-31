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

    /// <summary>
    /// Claims added to user.
    /// </summary>
    [NotMapped]
    public IReadOnlyCollection<Claim> PrivateClaims
    {
        get { return UserClaims.Select(p => new Claim(p.ClaimType, p.ClaimValue)).ToList(); }
    }

    /// <summary>
    /// Union of claims added to user and claims added to user's roles.
    /// </summary>
    [NotMapped]
    public IReadOnlyCollection<Claim> Claims
    {
        get
        {
            return UserClaims.Select(p => new Claim(p.ClaimType, p.ClaimValue))
                .Union(Roles.SelectMany(p => p.Claims.Select(c => new Claim(c.ClaimType, c.ClaimValue)))).ToList();
        }
    }
}