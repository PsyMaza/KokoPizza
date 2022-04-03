using System.Collections.Concurrent;
using KokoPizza.Core.Application.Contracts.Infrastructure;
using KokoPizza.Core.Application.Models.Notification;

namespace KokoPizza.Infrastructure.Infrastructure.Notifications;

public class NotificationService : INotificationService, IBackgroundService
{
    private bool _isRunning = false;
    private CancellationToken _cancellationToken;
    private ConcurrentQueue<BaseNotification> _queue = new();

    public bool IsRunning => _isRunning;
    private CancellationToken CancellationToken => _cancellationToken;

    public void AddToSendNotification(BaseNotification notification)
    {
        _queue.Enqueue(notification);
    }

    private async Task SendNotifications()
    {
        using var semaphoreSlim = new SemaphoreSlim(Environment.ProcessorCount / 3);

        var tasks = _queue.Select(notification => Task.Run(async () =>
        {
            await semaphoreSlim.WaitAsync();

            try
            {
                await NotificationSending(notification);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }));

        await Task.WhenAll(tasks);
    }

    private async Task NotificationSending(BaseNotification notification)
    {
        await Task.Delay(10);
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        if (!_isRunning)
        {
            _isRunning = true;

            while (!cancellationToken.IsCancellationRequested)
            {
                await SendNotifications();
                await Task.Delay(1000, cancellationToken);
            }

            _isRunning = false;
        }
    }
}