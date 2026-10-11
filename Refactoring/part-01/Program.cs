using RefactoringLab;

var shipping = new ShippingCostCalculator();
Console.WriteLine($"Aramex 2kg → {shipping.Calculate(new Aramex(), 2)}");
Console.WriteLine($"FedEx 2kg  → {shipping.Calculate(new FedEx(), 2)}");
Console.WriteLine($"EgyptPost 2kg → {shipping.Calculate(new EgyptPost(), 2)}");
Console.WriteLine();

var processor = new OrderProcessor(new SqlOrderRepository(), new SmtpEmailSender());
processor.Process(1001, "customer@example.com");
Console.WriteLine();

var emailNote = new Notification(new EmailChannel());
emailNote.SetScheduledDate(DateTime.Today.AddHours(18));
emailNote.MarkAsUrgent();
emailNote.Send("customer@example.com", "Your order ships tomorrow");

var smsNote = new Notification(new SmsChannel());
smsNote.MarkAsUrgent();
smsNote.Send("+201000000000", "OTP 4821");

var whatsappNote = new Notification(new WhatsappChannel());
whatsappNote.Send("+201111111111", "Hello from WhatsApp!");

