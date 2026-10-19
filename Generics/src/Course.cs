namespace Generics;

public class Course : IHasId
{
    public int Id { get; init; }
    public string Title { get; init; } = "";
    public decimal Price { get; init; }

    public override string ToString() => $"{Id}: {Title} ({Price} EGP)";
}