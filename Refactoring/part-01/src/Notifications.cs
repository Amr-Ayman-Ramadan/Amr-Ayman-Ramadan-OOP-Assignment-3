namespace RefactoringLab;

// Composition over inheritance:
// a Notification HAS a channel, and urgent / scheduled are just options.
// Any channel x {normal, urgent, scheduled, urgent+scheduled} = one class, not one class per combination.
public class Notification
{
    private readonly INotificationChannel _channel;

    public Notification(INotificationChannel channel)
    {
        _channel = channel;
    }

    public bool IsUrgent { get; init; }
    public DateTime? SendAt { get; init; }

    public void Send(string to, string message)
    {
        var text = IsUrgent ? $"[URGENT] {message}" : message;
        _channel.Deliver(to, text, SendAt);
    }
}