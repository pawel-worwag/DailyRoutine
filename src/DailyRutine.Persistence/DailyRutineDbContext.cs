using System.Reflection;
using DailyRutine.Application.Comon.Interfaces;
using DailyRutine.Domain.Entities;
using DailyRutine.Domain.Entities.Entries;
using Microsoft.EntityFrameworkCore;

namespace DailyRutine.Persistence;

public class DailyRutineDbContext : DbContext, IDailyRutineDbContext
{
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<TextEntry> TextEntries { get; set; }
    public DbSet<DecimalEntry> DecimalEntries { get; set; }
    public DbSet<ToDoEntry> ToDoEntries { get; set; }
    public DbSet<NutritionEntry> NutritionEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}