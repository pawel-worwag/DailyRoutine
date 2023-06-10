using Mailer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mailer.Persistence.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Domain.Entities.Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("Languages");
        builder.HasKey(p => p.CultureName);
        builder.Property(p => p.CultureName).HasMaxLength(30).IsRequired();
    }
}