using DailyRoutine.Domain.Entities.Entries;
using DailyRoutine.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyRoutine.Persistence.Configurations;

public class NutrionEntryConfiguration : IEntityTypeConfiguration<Domain.Entities.Entries.NutritionEntry>
{
    public void Configure(EntityTypeBuilder<NutritionEntry> builder)
    {
        //Table
        builder.ToTable("NutrionEntries");
        //Primary Key
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Guid).IsRequired();
        builder.HasIndex(p => p.Guid).IsUnique();
        //Type
        builder.Ignore(p => p.Type);
        //Date
        builder.Property(p => p.Date).IsRequired();
        //Values
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Weight).IsRequired().HasDefaultValue(0);
        builder.Property(p => p.Unit).IsRequired().HasDefaultValue(WeightUnit.G);
        builder.Property(p => p.Energy).IsRequired().HasDefaultValue(0);
        
        //Relations
        builder.HasOne(p => p.Section)
            .WithMany()
            .HasForeignKey("SectionId")
            .IsRequired();
        builder.HasOne(p => p.Calendar)
            .WithMany(p => p.NutritionEntries)
            .HasForeignKey("CalendarId")
            .IsRequired();
    }
}