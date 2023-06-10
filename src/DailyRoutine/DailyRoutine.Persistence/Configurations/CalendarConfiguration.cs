using DailyRoutine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyRoutine.Persistence.Configurations;

public class CalendarConfiguration : IEntityTypeConfiguration<Domain.Entities.Calendar>
{
    public void Configure(EntityTypeBuilder<Calendar> builder)
    {
        builder.ToTable("Calendars");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Guid).IsRequired();
        builder.HasIndex(p => p.Guid).IsUnique();
        builder.Property(p => p.Owner).IsRequired();
        builder.Property(p => p.Name).IsRequired();
    }
}