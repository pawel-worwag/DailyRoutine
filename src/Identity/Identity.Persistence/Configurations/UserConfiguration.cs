using Identity.Domain;
using Identity.Domain.Entities;
using Identity.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    }
}