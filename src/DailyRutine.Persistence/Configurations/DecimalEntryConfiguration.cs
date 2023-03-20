using DailyRutine.Domain.Entities.Entries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyRutine.Persistence.Configurations;

public class DecimalEntryConfiguration : IEntityTypeConfiguration<Domain.Entities.Entries.DecimalEntry>
{
    public void Configure(EntityTypeBuilder<DecimalEntry> builder)
    {
        //Table
        builder.ToTable("DecimalEntries");
        //Primary Key
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Guid).IsRequired();
        builder.HasIndex(p => p.Guid).IsUnique();
        //Type
        builder.Ignore(p => p.Type);
        //Date
        builder.Property(p => p.Date).IsRequired();
        //Values
        builder.Property(p => p.Value).IsRequired().HasDefaultValue(0);
        //Relations
        builder.HasOne(p => p.Section)
            .WithMany()
            .HasForeignKey("SectionId")
            .IsRequired();
        builder.HasOne(p => p.Calendar)
            .WithMany(p => p.DecimalEntries)
            .HasForeignKey("CalendarId")
            .IsRequired();
    }
}