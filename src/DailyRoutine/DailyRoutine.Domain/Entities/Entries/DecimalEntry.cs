using DailyRoutine.Domain.Entities.Enums;

namespace DailyRoutine.Domain.Entities.Entries;

public class DecimalEntry : Entry
{
    public EntryType Type { get; private set; } = EntryType.DECIMAL;
    public decimal Value { get; set; } = 0;
}