using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Configurations;

public class EmailConfirmationTokenConfiguration : IEntityTypeConfiguration<Domain.EmailConfirmationToken>
{
    public void Configure(EntityTypeBuilder<Domain.EmailConfirmationToken> builder)
    {
        builder.ToTable("UserRegistrationTokens");
        builder.HasKey(p => p.UserId);
        builder.Property(p => p.ValidBefore).IsRequired();
        builder.Property(p => p.Token).IsRequired();
        builder.HasIndex(p => p.Token).IsUnique();
    }
}