using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Configurations;

public class RegistrationTokenConfiguration : IEntityTypeConfiguration<Domain.Entities.RegistrationToken>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.RegistrationToken> builder)
    {
        builder.ToTable("UserRegistrationTokens");
        builder.HasKey(p => p.Guid);
        builder.Property(p=>p.Guid).HasColumnType("uuid").IsRequired();
        builder.Property(p => p.ValidAfter).IsRequired();
        builder.Property(p => p.ValidBefore).IsRequired();
        builder.HasOne(p => p.User).WithOne();
    }
}