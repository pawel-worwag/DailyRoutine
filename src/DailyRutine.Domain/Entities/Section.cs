using DailyRutine.Domain.Entities.Enums;

namespace DailyRutine.Domain.Entities;

public class Section
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; } = String.Empty;
    public Calendar Calendar { get; set; }
    public SectionType Type { get; set; } = SectionType.TEXT;
}