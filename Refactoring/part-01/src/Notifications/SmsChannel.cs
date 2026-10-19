namespace RefactoringLab;

public class SmsChannel : INotificationChannel
{
    public void Deliver(string to, string message, DateTime? sendAt)
    {
        var tag = sendAt is null ? "sms" : $"sms scheduled {sendAt.Value:g}";
        Console.WriteLine($"[{tag}] {to}: {message}");
    }
}