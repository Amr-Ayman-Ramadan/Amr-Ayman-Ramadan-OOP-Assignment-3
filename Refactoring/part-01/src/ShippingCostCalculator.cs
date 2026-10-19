namespace RefactoringLab;

// Open for extension, closed for modification:
// no switch here any more - the carriers are passed in from outside.
public class ShippingCostCalculator
{
    private readonly Dictionary<string, ICarrier> _carriers = new();

    public ShippingCostCalculator(IEnumerable<ICarrier> carriers)
    {
        foreach (var carrier in carriers)
            _carriers[carrier.Name] = carrier;
    }

    public decimal Calculate(string carrier, decimal weightKg)
    {
        if (!_carriers.TryGetValue(carrier, out var found))
            throw new ArgumentException($"Unknown carrier: {carrier}");

        return found.Calculate(weightKg);
    }
}