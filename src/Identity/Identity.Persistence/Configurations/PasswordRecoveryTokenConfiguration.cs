using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Configurations;

public class PasswordRecoveryTokenConfiguration :  IEntityTypeConfiguration<Domain.Entities.PasswordRecoveryToken>
{
    public void Configure(EntityTypeBuilder<PasswordRecoveryToken> builder)
    {
        builder.ToTable("PasswordRecoveryTokens");
        builder.HasKey(p=>p.Token);
        builder.HasIndex("UserId");
        builder.Property(p => p.ValidAfter).IsRequired();
        builder.Property(p => p.ValidBefore).IsRequired();
    }
}