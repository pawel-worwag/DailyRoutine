using Mailer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mailer.Persistence.Configurations;

public class TemplateConfiguration : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.ToTable("Templates");
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Guid).IsUnique();
        builder.Property(p => p.Guid).IsRequired();
        builder.HasOne(p => p.Type).WithMany().IsRequired();
        builder.HasOne(p => p.Language).WithMany().IsRequired();
        builder.Property(p => p.Subject).IsRequired();
        builder.Property(p => p.BodyEncoded).IsRequired();
        builder.HasMany(typeof(Attachment), "_attachments")
            .WithMany(nameof(Attachment.Templates))
            .UsingEntity(j => j.ToTable("TemplateAttachments"));
    }
}