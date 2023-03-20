using DailyRutine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyRutine.Persistence.Configurations;

public class SectionConfiguration : IEntityTypeConfiguration<Domain.Entities.Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.ToTable("Sections");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Guid).IsRequired();
        builder.HasIndex(p => p.Guid).IsUnique();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Type).IsRequired();
        builder.HasOne(p => p.Calendar)
            .WithMany(p => p.Sections)
            .HasForeignKey("CalendarId")
            .IsRequired();
    }
}