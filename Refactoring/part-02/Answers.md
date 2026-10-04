# Part 02 — answers

---

## Reports

- What was the problem?
  The three report exporter classes duplicated the exact same workflow steps (loading data, validating it, and saving it to a file).
- What did you change?
  Applied the Template Method pattern by extracting the common steps into an abstract base class (`ReportExporter`). Only the step that varies (the `Format` method) was left abstract for the subclasses (`CsvReportExporter`, etc.) to implement.
- Why did you choose that approach? (Why an abstract class and not an interface?)
  An abstract class is a better fit than an interface in this case because an abstract class allows us to define the actual implementation for the shared steps (`Load`, `Validate`, and `Save`). An interface only defines a contract without implementation, meaning we would still have to duplicate the logic inside every single class.

---

## Enrollment

- What was the problem?
  The client (`Program.cs`) was tightly coupled to the internal workings of the enrollment process. It had to manually instantiate and orchestrate four different subsystems (`PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, `EmailService`) in a strict sequence just to enroll a student.
- What did you change?
  Implemented the Facade design pattern by creating an `EnrollmentFacade` class. This class wraps all the complex subsystem interactions into a single, easy-to-use `Enroll` method.
- Why did you choose that approach? (What problem does it solve?)
  The Facade pattern simplifies the client's interaction with the system. The caller no longer needs to know about the existence of the four services, nor do they need to know the specific order in which they must be called. They simply call one method, and the Facade handles the rest.
