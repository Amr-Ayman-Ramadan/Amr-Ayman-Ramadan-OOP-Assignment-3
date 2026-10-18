namespace RefactoringLab;

// NEW carrier - added without editing any existing class.
public class EgyptPostCarrier : ICarrier
{
    public string Name => "EgyptPost";
    public decimal Calculate(decimal weightKg) => weightKg * 8m;
}