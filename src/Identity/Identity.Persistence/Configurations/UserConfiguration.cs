using System.Globalization;
using System.Linq.Expressions;
using Identity.Domain;
using Identity.Domain.Entities;
using Identity.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Identity.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Guid).IsUnique();
        builder.Property(p => p.Guid).IsRequired();
        builder.Property(p => p.NormalizedEmail).IsRequired().HasConversion<string>(address => address.Value, s => new NormalizedEmailAddress(s) );
        builder.HasMany(p => p.Roles)
            .WithMany(p => p.Users);
        builder.HasMany(typeof(UserClaim), "UserClaims")
            .WithOne(nameof(UserClaim.User))
            .HasForeignKey("Id");
        builder.HasOne(typeof(EmailConfirmationToken),"EmailConfirmationToken")
            .WithOne(nameof(EmailConfirmationToken.User));
        builder.HasMany(typeof(PasswordRecoveryToken), "_passwordRecoveryTokens")
            .WithOne(nameof(PasswordRecoveryToken.User)).HasForeignKey("UserId");
        builder.Property(p => p.Culture).HasConversion<string>(culture => culture.Name, s => GetCulture(s));
        builder.Property(p => p.TimeZone)
            .HasConversion<string>(zone => zone.Id, s => GetTz(s));
    }

    private TimeZoneInfo GetTz(string id)
    {
        try
        {
            return TimeZoneInfo.FindSystemTimeZoneById(id);
        }
        catch
        {
            return TimeZoneInfo.Utc;;
        }
    }

    private CultureInfo GetCulture(string name)
    {
        try
        {
            return CultureInfo.GetCultureInfo(name);
        }
        catch
        {
            return CultureInfo.GetCultureInfo("pl");
        }
    }
}