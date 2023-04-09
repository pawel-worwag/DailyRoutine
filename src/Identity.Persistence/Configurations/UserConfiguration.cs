using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasIndex(p => p.Guid).IsUnique();
        builder.Property(p => p.Guid).IsRequired();
        builder.Property(p => p.DisplayName).IsRequired();
    }
}