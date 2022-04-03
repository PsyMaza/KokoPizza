using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Delivery.Application;

public static class DeliveryApplicationRegistration
{
    public static IServiceCollection AddDeliveryApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
    
            return services;
        }
}