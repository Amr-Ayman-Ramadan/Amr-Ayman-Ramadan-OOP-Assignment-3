# Part 01 — answers

---

## ShippingCostCalculator

- **What was the problem?**
  The price of every carrier was hard-coded inside one `switch`. To add a new carrier I had to open this class and add a new `case`, so the class was never "closed". This breaks the Open/Closed Principle, and every change risks breaking the carriers that already work.
- **What did you change?**
  I created an `ICarrier` interface (`Name` + `Calculate(weightKg)`) and moved each carrier into its own class: `AramexCarrier`, `FedExCarrier`, `DhlCarrier`. The calculator now receives the carriers in its constructor, keeps them in a `Dictionary<string, ICarrier>` by name, and just asks the right carrier for the price. The `switch` is gone. An unknown carrier still throws the same `ArgumentException`.

---

## OrderProcessor

- **What was the problem?**
  `OrderProcessor` created `SqlOrderRepository` and `SmtpEmailSender` itself with `new`, and read `DateTime.Now` directly. So it was hard-wired to SQL, SMTP and the real clock: I could not swap the database or the email sender, and I could not test it without writing to them. This breaks the Dependency Inversion Principle. It also called `DateTime.Now` twice, so the saved time and the time in the email could be different.
- **What did you change?**
  I added two interfaces, `IOrderRepository` and `IEmailSender`, and made `SqlOrderRepository` and `SmtpEmailSender` implement them. `OrderProcessor` now receives an `IOrderRepository`, an `IEmailSender` and a `TimeProvider` through its constructor (constructor injection). `Program.cs` decides which real classes to use. I also read the time once and use the same value for saving and for the email.

---

## Notifications

- **What was the problem?**
  Every combination was a new subclass: `EmailNotification`, `UrgentEmailNotification`, `UrgentScheduledEmailNotification`, and the same again for SMS. The number of classes grows as *channels × options* (class explosion). There was no "scheduled but not urgent" class, so adding it would mean even more classes. The scheduled classes also did not call `base`, so the formatting was copied. Adding a new channel would mean writing the whole tree again.
- **What did you change?**
  I used composition over inheritance. A channel (`EmailChannel`, `SmsChannel`) only knows how to deliver a message and implements `INotificationChannel`. "Urgent" and "scheduled" are not types any more — they are options (`IsUrgent`, `SendAt`) on one `Notification` class that **has** a channel. So any channel can be sent normal, urgent, scheduled, or urgent + scheduled with the same class.

---

## Proof

- **New carrier file(s):** `src/Shipping/EgyptPostCarrier.cs`
- **New notification channel file(s):** `src/Notifications/WhatsAppChannel.cs`
- **Existing classes left unchanged? (yes/no):** yes — the new carrier and the new channel are new classes only; the only existing file I edited to wire them in is `Program.cs`. `Program.cs` shows WhatsApp sent normal, urgent, scheduled, and urgent + scheduled.