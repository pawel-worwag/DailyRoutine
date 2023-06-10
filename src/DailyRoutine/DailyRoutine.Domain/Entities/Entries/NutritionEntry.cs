using DailyRoutine.Domain.Entities.Enums;

namespace DailyRoutine.Domain.Entities.Entries;

public class NutritionEntry : Entry
{
    public EntryType Type { get; private set; } = EntryType.NUTRITION;
    public string Name { get; set; } = String.Empty;
    public decimal Weight { get; set; } = 0;
    public WeightUnit Unit { get; set; } = WeightUnit.G;
    public decimal Energy { get; set; } = 0;
    public decimal? Fat { get; set; }
    public decimal? SaturatedFat { get; set; }
    public decimal? Carbohydrate { get; set; }
    public decimal? Sugar { get; set; }
    public decimal? Protein { get; set; }
    public decimal? Salt { get; set; }
    public string? Description { get; set; }
}