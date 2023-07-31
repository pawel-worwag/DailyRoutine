using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Configurations;

public class RecoveryTokenConfiguration :  IEntityTypeConfiguration<Domain.Entities.RecoveryPasswordToken>
{
    public void Configure(EntityTypeBuilder<RecoveryPasswordToken> builder)
    {
        builder.ToTable("UserRecoveryPasswordTokens");
        builder.HasKey(p => p.Guid);
        builder.Property(p=>p.Guid).HasColumnType("uuid").IsRequired();
        builder.Property(p => p.ValidAfter).IsRequired();
        builder.Property(p => p.ValidBefore).IsRequired();
        //builder.HasOne(p => p.User).WithMany().HasForeignKey(p=>p.UserId).IsRequired();
        builder.Property(p => p.Token).IsRequired();
        builder.HasIndex(p => p.Token).IsUnique();
    }
}