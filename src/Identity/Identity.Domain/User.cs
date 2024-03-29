using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Identity.Domain.Entities;
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
    
    protected EmailConfirmationToken? EmailConfirmationToken { get; private set; }

    public EmailConfirmationToken CreateEmailConfirmationToken(DateTime validBefore)
    {
        EmailConfirmationToken = new EmailConfirmationToken(this, validBefore);
        return EmailConfirmationToken;
    }

    protected HashSet<PasswordRecoveryToken> _passwordRecoveryTokens { get; private set; } =
        new HashSet<PasswordRecoveryToken>();

    public PasswordRecoveryToken CreatePasswordRecoveryToken(DateTime validAfter, DateTime validBefore)
    {
        var token = new PasswordRecoveryToken(this, validAfter, validBefore);
        _passwordRecoveryTokens.Add(token);
        return token;
    }

    public IReadOnlyCollection<PasswordRecoveryToken> PasswordRecoveryTokens => _passwordRecoveryTokens;
}