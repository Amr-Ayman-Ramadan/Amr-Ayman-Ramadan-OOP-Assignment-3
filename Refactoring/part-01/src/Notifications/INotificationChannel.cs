namespace RefactoringLab;

// A channel only knows HOW to deliver a message (email, sms, ...).
// "Urgent" and "scheduled" are not channels, so they are not subclasses any more.
public interface INotificationChannel
{
    void Deliver(string to, string message, DateTime? sendAt);
}