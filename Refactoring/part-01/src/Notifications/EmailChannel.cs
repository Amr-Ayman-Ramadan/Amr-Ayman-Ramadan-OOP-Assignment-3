namespace RefactoringLab;

public class EmailChannel : INotificationChannel
{
    public void Deliver(string to, string message, DateTime? sendAt)
    {
        var tag = sendAt is null ? "email" : $"email scheduled {sendAt.Value:g}";
        Console.WriteLine($"[{tag}] {to}: {message}");
    }
}