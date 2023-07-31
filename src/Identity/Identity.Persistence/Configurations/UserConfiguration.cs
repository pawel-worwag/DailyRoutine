using Identity.Domain;
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
            .WithMany(p => p.Users)
            .UsingEntity("RS_UsersRoles");
        /*
    "UsersRoles",
    l => l.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)),
    r => r.HasOne(typeof(Role)).WithMany().HasForeignKey("RoleId").HasPrincipalKey(nameof(Role.Id)),
    j=> j.HasKey("UserId", "RoleId"));*/
    }
}