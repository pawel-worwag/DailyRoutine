using DailyRoutine.Domain.Entities.Enums;

namespace DailyRoutine.Domain.Entities.Entries;

public class ToDoEntry : Entry
{
    public EntryType Type { get; private set; } = EntryType.TODO;
    public string Title { get; set; } = String.Empty;
    public bool Value { get; set; } = false;
    public DateTime? Done { get; set; } = null;
}