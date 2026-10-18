using RefactoringLab;

var shipping = new ShippingCostCalculator(
[
    new AramexCarrier(),
    new FedExCarrier(),
    new DhlCarrier(),
    new EgyptPostCarrier()   
]);

Console.WriteLine($"Aramex 2kg → {shipping.Calculate("Aramex", 2)}");
Console.WriteLine($"FedEx 2kg  → {shipping.Calculate("FedEx", 2)}");
Console.WriteLine($"EgyptPost 2kg → {shipping.Calculate("EgyptPost", 2)}");
Console.WriteLine();
var processor = new OrderProcessor(new SqlOrderRepository(), new SmtpEmailSender(), TimeProvider.System); 
processor.Process(1001, "customer@example.com");
Console.WriteLine();

new Notification(new EmailChannel()) { IsUrgent = true, SendAt = DateTime.Today.AddHours(18) }
    .Send("customer@example.com", "Your order ships tomorrow");
new Notification(new SmsChannel()) { IsUrgent = true }
    .Send("+201000000000", "OTP 4821");

// New channel: normal, urgent, scheduled, and both - no extra classes needed.
var whatsApp = new WhatsAppChannel();
new Notification(whatsApp).Send("+201000000000", "Welcome!");
new Notification(whatsApp) { IsUrgent = true }.Send("+201000000000", "Payment failed");
new Notification(whatsApp) { SendAt = DateTime.Today.AddHours(9) }.Send("+201000000000", "Class starts at 10");
new Notification(whatsApp) { IsUrgent = true, SendAt = DateTime.Today.AddHours(20) }
    .Send("+201000000000", "Assignment due tonight");