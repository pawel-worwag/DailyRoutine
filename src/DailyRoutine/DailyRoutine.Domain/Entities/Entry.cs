using DailyRoutine.Domain.Entities.Enums;

namespace DailyRoutine.Domain.Entities;

public abstract class  Entry
{
     public int Id { get; set; }
     public Guid Guid { get;  set; } = Guid.NewGuid();
     public EntryType Type { get; set; } = EntryType.UNKNOWN;
     public Calendar Calendar { get; set; }
     public Section Section { get; set; }
     public DateTime Date { get; set; }
}