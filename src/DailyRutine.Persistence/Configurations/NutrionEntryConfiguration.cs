using DailyRutine.Domain.Entities.Entries;
using DailyRutine.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyRutine.Persistence.Configurations;

public class NutrionEntryConfiguration : IEntityTypeConfiguration<Domain.Entities.Entries.NutritionEntry>
{
    public void Configure(EntityTypeBuilder<NutritionEntry> builder)
    {
        //Table
        builder.ToTable("NutrionEntries");
        //Primary Key
        builder.HasKey(p => p.Guid);
        builder.Property(p => p.Guid).IsRequired();
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