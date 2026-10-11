using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text;

namespace RefactoringLab;

public interface INotificationChannel
{
    public string Channel {get;}
}

public class EmailChannel : INotificationChannel
{
    public string Channel {get; private set;} = "email";
}

public class SmsChannel : INotificationChannel
{
    public string Channel {get; private set;} = "sms";
}

public class WhatsappChannel : INotificationChannel
{
    public string Channel {get; private set;} = "whatsapp";
}

public class Notification
{
    public INotificationChannel NotificationChannel {get; private set;}
    public bool IsUrgent {get; private set;}
    public DateTime? SendAt {get; private set;}

    public Notification(INotificationChannel notificationChannel)
    {
        NotificationChannel = notificationChannel;
    }

    public void MarkAsUrgent()
    {
        IsUrgent = true;
    }

    public void SetScheduledDate(DateTime? at)
    {
        SendAt = at;
    }

    public void Send(string to, string message) {
        string notificationMessage = $"[{NotificationChannel.Channel}" + 
                                    (SendAt is not null ? $" scheduled {SendAt:g}" : "")  + $"] {to}: " + 
                                    (IsUrgent == true ? "[URGENT] " : "") + message;
        
        System.Console.WriteLine(notificationMessage);
    }
}