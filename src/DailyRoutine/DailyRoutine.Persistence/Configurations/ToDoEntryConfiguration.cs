using DailyRoutine.Domain.Entities.Entries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyRoutine.Persistence.Configurations;

public class ToDoEntryConfiguration : IEntityTypeConfiguration<Domain.Entities.Entries.ToDoEntry>
{
    public void Configure(EntityTypeBuilder<ToDoEntry> builder)
    {
        //Table
        builder.ToTable("ToDoEntries");
        //Primary Key
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Guid).IsRequired();
        builder.HasIndex(p => p.Guid).IsUnique();
        //Type
        builder.Ignore(p => p.Type);
        //Date
        builder.Property(p => p.Date).IsRequired();
        //Values
        builder.Property(p => p.Title).IsRequired();
        builder.Property(p => p.Value).IsRequired().HasDefaultValue(false);
        //Relations
        builder.HasOne(p => p.Section)
            .WithMany()
            .HasForeignKey("SectionId")
            .IsRequired();
        builder.HasOne(p => p.Calendar)
            .WithMany(p => p.ToDoEntries)
            .HasForeignKey("CalendarId")
            .IsRequired();
    }
}