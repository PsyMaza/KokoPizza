using KokoPizza.Core.Application.Contracts.Infrastructure;
using KokoPizza.Infrastructure.Infrastructure.FileExporter;
using KokoPizza.Infrastructure.Infrastructure.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace KokoPizza.Infrastructure.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<ICsvExporter, CsvExporter>();
        services.AddSingleton<INotificationService, NotificationService>();
        
        return services;
    }
}