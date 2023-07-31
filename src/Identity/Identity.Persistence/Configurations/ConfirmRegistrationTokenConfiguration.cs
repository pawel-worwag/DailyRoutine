using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Configurations;

public class ConfirmRegistrationTokenConfiguration : IEntityTypeConfiguration<Domain.Entities.ConfirmRegistrationToken>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.ConfirmRegistrationToken> builder)
    {
        builder.ToTable("UserRegistrationTokens");
        builder.HasKey(p => p.Guid);
        builder.Property(p=>p.Guid).HasColumnType("uuid").IsRequired();
        builder.Property(p => p.ValidAfter).IsRequired();
        builder.Property(p => p.ValidBefore).IsRequired();
        //builder.HasOne(p => p.User).WithOne();
        builder.Property(p => p.Token).IsRequired();
        builder.HasIndex(p => p.Token).IsUnique();
    }
}