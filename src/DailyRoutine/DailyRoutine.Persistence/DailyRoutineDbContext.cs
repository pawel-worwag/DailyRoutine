using System.Reflection;
using DailyRoutine.Application.Comon.Interfaces;
using DailyRoutine.Domain.Entities;
using DailyRoutine.Domain.Entities.Entries;
using Microsoft.EntityFrameworkCore;

namespace DailyRoutine.Persistence;

public class DailyRoutineDbContext : DbContext, IDailyRutineDbContext
{
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<TextEntry> TextEntries { get; set; }
    public DbSet<DecimalEntry> DecimalEntries { get; set; }
    public DbSet<ToDoEntry> ToDoEntries { get; set; }
    public DbSet<NutritionEntry> NutritionEntries { get; set; }

    public DailyRoutineDbContext(DbContextOptions<DailyRoutineDbContext> options) : base(options)
    {
            
    }
    
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