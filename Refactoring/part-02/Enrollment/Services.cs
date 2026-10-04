namespace RefactoringLab.Part02.Enrollment;

public class EnrollmentFacade
{
    public void Enroll(string studentId, string courseId, decimal amount)
    {
        var payment = new PaymentGateway();
        var seats = new SeatInventory();
        var invoices = new InvoiceGenerator();
        var email = new EmailService();

        payment.Charge(studentId, amount);
        seats.Reserve(courseId, studentId);
        var invoiceId = invoices.Create(studentId, amount);
        email.Send(studentId, "Enrollment confirmed", $"Invoice {invoiceId} for {courseId}");
    }
}
public class PaymentGateway
{
    public void Charge(string studentId, decimal amount) =>
        Console.WriteLine($"charge {studentId}: {amount}");
}

public class SeatInventory
{
    public void Reserve(string courseId, string studentId) =>
        Console.WriteLine($"reserve seat {courseId} for {studentId}");
}

public class InvoiceGenerator
{
    public string Create(string studentId, decimal amount)
    {
        var invoiceId = $"INV-{studentId}-{amount}";
        Console.WriteLine($"invoice {invoiceId}");
        return invoiceId;
    }
}

public class EmailService
{
    public void Send(string studentId, string subject, string body) =>
        Console.WriteLine($"email {studentId}: {subject} / {body}");
}
