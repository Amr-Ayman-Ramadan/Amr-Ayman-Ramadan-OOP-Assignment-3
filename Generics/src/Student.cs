namespace Generics;

public class Student : IHasId
{
    public int Id { get; init; }
    public string Name { get; init; } = "";

    public override string ToString() => $"{Id}: {Name}";
}