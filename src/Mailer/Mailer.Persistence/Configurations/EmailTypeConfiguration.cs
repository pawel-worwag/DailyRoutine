using Mailer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mailer.Persistence.Configurations;

public class EmailTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.EmailType>
{
    public void Configure(EntityTypeBuilder<EmailType> builder)
    {
        builder.ToTable("EmailTypes");
        builder.HasKey(p => p.TypeName);
        builder.Property(p => p.TypeName).HasMaxLength(30).IsRequired();
    }
}