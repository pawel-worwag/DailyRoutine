using System.ComponentModel.DataAnnotations.Schema;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Identity.Domain.ValueObjects;
using Claim = Identity.Domain.ValueObjects.Claim;

namespace Identity.Domain;

public class User
{
    public int Id { get; private set; }
    public Guid Guid { get; private set; } = Guid.NewGuid();
    public NormalizedEmailAddress NormalizedEmail { get; set; } = default!;
    public bool EmailConfirmed { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public HashSet<Role> Roles { get; private set; } = new HashSet<Role>();
    protected ICollection<UserClaim> UserClaims { get; private set; } = new List<UserClaim>();

    /// <summary>
    /// Claims added to user.
    /// </summary>
    [NotMapped]
    public IReadOnlyCollection<Claim> PersonalClaims
    {
        get { return UserClaims.Select(p => new Claim(p.ClaimType, p.ClaimValue)).ToList(); }
    }

    /// <summary>
    /// Add personal claim
    /// </summary>
    /// <param name="claim"></param>
    public void AddPersonalClaim(UserClaim claim)
    {
        if (!UserClaims.Contains(claim))
        {
            UserClaims.Add(claim);
        }
    }

    /// <summary>
    /// Add personal claims
    /// </summary>
    /// <param name="claims"></param>
    public void AddPersonalClaims(ICollection<UserClaim> claims)
    {
        foreach (var claim in claims)
        {
            AddPersonalClaim(claim);
        }
    }
    
    /// <summary>
    /// Remove personal claim
    /// </summary>
    /// <param name="claim"></param>
    public void RemovePersonalClaim(UserClaim claim)
    {
        UserClaims.Remove(claim);
    }

    /// <summary>
    /// Remove all personal claims
    /// </summary>
    public void RemovePersonalClaims()
    {
        UserClaims.Clear();
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

    public EmailStatus EmailStatus
    {
        get
        {
            if (EmailConfirmed == true)
            {
                return EmailStatus.Confirmed;
            }

            if (EmailConfirmationToken is null)
            {
                return EmailStatus.Uninitialized;
            }

            return EmailStatus.Idle;
        }
    }

    protected HashSet<PasswordRecoveryToken> _passwordRecoveryTokens { get; private set; } =
        new HashSet<PasswordRecoveryToken>();

    public PasswordRecoveryToken CreatePasswordRecoveryToken(DateTime validAfter, DateTime validBefore)
    {
        var token = new PasswordRecoveryToken(this, validAfter, validBefore);
        _passwordRecoveryTokens.Add(token);
        return token;
    }
    
    [NotMapped]
    public IReadOnlyCollection<PasswordRecoveryToken> PasswordRecoveryTokens => _passwordRecoveryTokens;

    public void RemoveRecoveryTokens()
    {
        _passwordRecoveryTokens.Clear();
    }
}