using DailyRutine.Domain.Entities.Entries;

namespace DailyRutine.Domain.Entities;

public class Calendar
{
    public Guid Guid { get; set; } = Guid.NewGuid();
    public Guid Owner { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Section> Sections { get; set; } = new List<Section>();
    public ICollection<TextEntry> TextEntries { get; set; } = new List<TextEntry>();
    public ICollection<ToDoEntry> ToDoEntries { get; set; } = new List<ToDoEntry>();
    public ICollection<DecimalEntry> DecimalEntries { get; set; } = new List<DecimalEntry>();
    public ICollection<NutritionEntry> NutritionEntries { get; set; } = new List<NutritionEntry>();
}