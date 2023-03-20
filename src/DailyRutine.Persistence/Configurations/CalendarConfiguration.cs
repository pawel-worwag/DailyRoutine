using DailyRutine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyRutine.Persistence.Configurations;

public class CalendarConfiguration : IEntityTypeConfiguration<Domain.Entities.Calendar>
{
    public void Configure(EntityTypeBuilder<Calendar> builder)
    {
        builder.ToTable("Calendars");
        builder.HasKey(p => p.Guid);
        builder.Property(p => p.Guid).IsRequired();
        builder.Property(p => p.Owner).IsRequired();
        builder.Property(p => p.Name).IsRequired();
    }
}