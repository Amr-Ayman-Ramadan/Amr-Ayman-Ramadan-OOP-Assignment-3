# Part 02 — answers

---

## Reports

- **What was the problem?**
  `CsvReportExporter`, `JsonReportExporter` and `TextReportExporter` were almost copies of each other. `Export`, `Load`, `Validate` and `Save` were the same in all three — only `Format` was different. If I wanted to change a step (for example the validation rule) or the order of the steps, I had to change it in three places and could easily forget one.
- **What did you change?**
  I created an abstract class `ReportExporter` that uses the **Template Method** pattern. Its `Export` method is the template: it runs Load → Validate → Format → Save, and it is the only place where the steps and their order are written. `Load`, `Validate` and `Save` are written once in the base class. `Format` is `abstract`, so each exporter now only overrides `Format` — the only thing that is different about it. The three report files are written with the same content as before.
- **Why did you choose that approach? (why an abstract class and not an interface?)**
  The Template Method pattern needs two things: shared code and a fixed algorithm that subclasses cannot change. An abstract class gives both: it can contain the real implementation of `Export`, `Load`, `Validate` and `Save`, it can keep `Save` `private` and the helper steps `protected` so outside code cannot call them, it can force subclasses to write `Format` with `abstract`, and because `Export` is not `virtual`, no subclass can change the order of the steps. An interface is only a contract — every class would still have to write `Export` and the shared steps itself (so the duplication comes back), and every member of an interface is public.

---

## Enrollment

- **What was the problem?**
  To enroll one student, `Program.cs` had to create four services (`PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, `EmailService`) itself and call them one by one in the correct order, passing the invoice id from one to the next. Every caller that wants to enroll a student must know all four classes and the exact order, so this knowledge would be copied everywhere, and calling them in the wrong order (for example sending the email before charging) would be a bug.
- **What did you change?**
  I added an `EnrollmentFacade` class with one method: `Enroll(studentId, courseId, amount)`. The facade creates the four services and calls them in the right order. `Program.cs` now enrolls a student with one call and no longer creates or calls the four services. `Services.cs` was not changed and the output is the same.
- **Why did you choose that approach? (what problem does the Facade solve, and what does the caller no longer need to know?)**
  The Facade gives a simple front door to a complicated subsystem. The caller no longer needs to know which four services exist, how to create them, the order they must be called in, or that the invoice id from `InvoiceGenerator` must be passed to the email. If the workflow changes later (for example a new step), only the facade changes, not every caller.