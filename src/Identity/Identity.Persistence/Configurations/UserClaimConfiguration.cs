using Identity.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Configurations;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("UserClaims");
        builder.HasKey(p => new { p.Id, p.ClaimType, p.ClaimValue });
        builder.HasIndex(p => p.Id);
        builder.Property(p => p.ClaimType).IsRequired();
        builder.Property(p => p.ClaimValue).IsRequired();
    }
}