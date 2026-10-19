namespace RefactoringLab;

// NEW channel - added without editing any existing class.
public class WhatsAppChannel : INotificationChannel
{
    public void Deliver(string to, string message, DateTime? sendAt)
    {
        var tag = sendAt is null ? "whatsapp" : $"whatsapp scheduled {sendAt.Value:g}";
        Console.WriteLine($"[{tag}] {to}: {message}");
    }
}