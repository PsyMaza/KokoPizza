using KokoPizza.Core.Application.Models.Notification;

namespace KokoPizza.Core.Application.Contracts.Infrastructure;

public interface INotificationService
{
    void AddToSendNotification(BaseNotification notification);
}