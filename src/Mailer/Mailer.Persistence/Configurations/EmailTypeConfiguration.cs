using Mailer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mailer.Persistence.Configurations;

public class EmailTypeConfiguration : IEntityTypeConfiguration<EmailType>
{
    public void Configure(EntityTypeBuilder<EmailType> builder)
    {
        builder.ToTable("EmailTypes");
        builder.HasKey(p => p.Name);
        builder.Property(p => p.Name).HasMaxLength(30).IsRequired();
    }
}