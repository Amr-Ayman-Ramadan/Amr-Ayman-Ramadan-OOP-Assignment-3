namespace RefactoringLab;

// Every carrier knows its own name and how to price a shipment.
// The calculator only talks to this interface, so a new carrier = a new class.
public interface ICarrier
{
    string Name { get; }
    decimal Calculate(decimal weightKg);
}