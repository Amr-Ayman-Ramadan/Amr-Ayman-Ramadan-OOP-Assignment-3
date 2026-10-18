namespace RefactoringLab;

// Depends on abstractions (DIP). It no longer creates its own repository,
// email sender or clock - they are given to it through the constructor.
public class OrderProcessor
{
    private readonly IOrderRepository _repository;
    private readonly IEmailSender _emailSender;
    private readonly TimeProvider _clock;

    public OrderProcessor(IOrderRepository repository, IEmailSender emailSender, TimeProvider clock)
    {
        _repository = repository;
        _emailSender = emailSender;
        _clock = clock;
    }

    public void Process(int orderId, string customerEmail)
    {
        // Read the time once, so the saved time and the email time are the same.
        var now = _clock.GetLocalNow().LocalDateTime;
        _repository.Save(orderId, now);
        _emailSender.Send(customerEmail, $"Order {orderId} confirmed at {now}");
    }
}