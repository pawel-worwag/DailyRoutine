namespace DailyRutine.Domain.Entities;

public class Section
{
    public Guid Guid { get; set; }
    public string Name { get; set; } = String.Empty;
    public Calendar Calendar { get; set; }
    public SectionType Type { get; set; } = SectionType.TEXT;
}