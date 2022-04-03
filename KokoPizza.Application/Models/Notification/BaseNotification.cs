namespace KokoPizza.Core.Application.Models.Notification;

public class BaseNotification
{
    public string To { get; set; }
    
    public string Subject { get; set; }
    
    public string Body { get; set; }
}