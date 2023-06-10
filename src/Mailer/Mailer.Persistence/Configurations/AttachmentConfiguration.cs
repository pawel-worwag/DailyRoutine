using Mailer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mailer.Persistence.Configurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<Domain.Entities.Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ToTable("Attachments");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Guid).IsRequired();
        builder.HasIndex(p => p.Guid).IsUnique();
        builder.Property(p => p.Path).IsRequired();
        builder.Property(p => p.MediaType).IsRequired();
        builder.Property(p => p.Inline).IsRequired().HasDefaultValue(false);
    }
}