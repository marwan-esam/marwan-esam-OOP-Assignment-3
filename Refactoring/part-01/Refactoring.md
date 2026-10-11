# Part 01 — answers

---

## ShippingCostCalculator

- What was the problem?
  The class violated the Open-Closed Principle (OCP). It used a hardcoded `switch` statement based on strings, meaning that adding a new carrier required modifying the existing code of the calculator.
- What did you change?
  Refactored using the Strategy Pattern. Extracted an `ICarrier` interface with a `Calculate` method. Created separate classes for each carrier (`Aramex`, `FedEx`, `DHL`) that implement this interface. The calculator now accepts an `ICarrier` object, allowing new carriers to be added without modifying the calculator class.

---

## OrderProcessor

- What was the problem?
  The class violated the Dependency Inversion Principle (DIP). It was tightly coupled to concrete implementations (`SqlOrderRepository` and `SmtpEmailSender`) by instantiating them directly with the `new` keyword, making it hard to test, extend, or swap out dependencies.
- What did you change?
  Extracted interfaces (`IOrderRepository` and `IEmailSender`) and used Dependency Injection (Constructor Injection) to pass these dependencies into `OrderProcessor`. Now, the processor relies on abstractions instead of concrete implementations.

---

## Notifications

- What was the problem?
  The code suffered from an "exploding inheritance tree". For every combination of channel, urgency, and scheduling, a new subclass was required (e.g., `UrgentScheduledEmailNotification`), making the design rigid and unscalable.
- What did you change?
  Applied Composition over Inheritance. Extracted an `INotificationChannel` interface (with implementations like `EmailChannel` and `SmsChannel`). The single `Notification` class now holds a reference to a channel via composition and handles properties like `IsUrgent` and `SendAt` internally, allowing us to delete all the unnecessary subclasses.

---

## Proof

- New carrier file(s): `EgyptPost` class added in `ShippingCostCalculator.cs`
- New notification channel file(s): `WhatsappChannel` class added in `Notifications.cs`
- Existing classes left unchanged? (yes/no): yes
