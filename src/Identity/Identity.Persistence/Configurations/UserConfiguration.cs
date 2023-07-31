using Identity.Domain.Entities;
using Identity.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<Domain.Entities.User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Guid).IsUnique();
        builder.Property(p => p.Guid).IsRequired();
        builder.Property(p => p.NormalizedEmail).HasConversion<string>(address => address.Value, s => new NormalizedEmailAddress(s) );
    }
}