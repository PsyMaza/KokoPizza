using System.Reflection;
using FluentValidation;
using KokoPizza.Core.Application.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace KokoPizza.Core.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));

        return services;
    }
}