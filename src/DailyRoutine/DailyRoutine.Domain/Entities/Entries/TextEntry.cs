using DailyRoutine.Domain.Entities.Enums;

namespace DailyRoutine.Domain.Entities.Entries;

public class TextEntry : Entry
{
    public EntryType Type { get; private set; } = EntryType.TEXT;
    public string Value { get; set; }
}