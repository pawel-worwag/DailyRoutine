using DailyRutine.Domain.Entities.Enums;

namespace DailyRutine.Domain.Entities;

public abstract class  Entry
{
     public Guid Guid { get;  set; } = Guid.NewGuid();
     public EntryType Type { get; set; } = EntryType.UNKNOWN;
     public Calendar Calendar { get; set; }
     public Section Section { get; set; }
     public DateTime Date { get; set; }
}