using DailyRutine.Domain.Entities;
using DailyRutine.Domain.Entities.Entries;
using Microsoft.EntityFrameworkCore;

namespace DailyRutine.Application.Comon.Interfaces;

public interface IDailyRutineDbContext
{
    DbSet<Calendar> Calendars { get; set; }
    DbSet<Section> Sections { get; set; }
    DbSet<TextEntry> TextEntries { get; set; }
    DbSet<DecimalEntry> DecimalEntries { get; set; }
    DbSet<ToDoEntry> ToDoEntries { get; set; }
    DbSet<NutritionEntry> NutritionEntries { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}