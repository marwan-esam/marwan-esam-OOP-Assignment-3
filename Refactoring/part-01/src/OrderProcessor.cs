namespace RefactoringLab;

public interface IOrderRepository
{
    public void Save(int orderId, DateTime processedAt);
}

public interface IEmailSender
{
    public void Send(string to, string body);
}

public class OrderProcessor
{
    public IOrderRepository OrderRepository {get; private set;}
    public IEmailSender EmailSender {get; private set;}

    public OrderProcessor(IOrderRepository orderRepository, IEmailSender emailSender)
    {
        OrderRepository = orderRepository;
        EmailSender = emailSender;
    }
    public void Process(int orderId, string customerEmail)
    {
        OrderRepository.Save(orderId, DateTime.Now);
        EmailSender.Send(customerEmail, $"Order {orderId} confirmed at {DateTime.Now}");
    }
}

public class SqlOrderRepository : IOrderRepository
{
    public void Save(int orderId, DateTime processedAt) =>
        Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
}

public class SmtpEmailSender : IEmailSender
{
    public void Send(string to, string body) =>
        Console.WriteLine($"[SMTP] to={to} body={body}");
}
