namespace Generics;

public class Student
{
    public int Id { get; init; }
    public string Name { get; init; } = "";

    public override string ToString() => $"{Id}: {Name}";
}