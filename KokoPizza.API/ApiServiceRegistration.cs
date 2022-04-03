using EventBus.Messages.Common;
using KokoPizza.API.EventBusConsumer;
using KokoPizza.API.Services;
using KokoPizza.API.Utility;
using KokoPizza.Core.Application.Contracts;
using MassTransit;
using Microsoft.OpenApi.Models;

namespace KokoPizza.API;

public static class ApiServiceRegistration
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwagger();

        services.AddScoped<ILoggedInUserService, LoggedInUserService>();

        // MassTransit-RabbitMQ Configuration
        services.AddMassTransit(config => {

            config.AddConsumer<OrderIsDeliveredConsumer>();

            config.UsingRabbitMq((ctx, cfg) => {
                cfg.Host(configuration["EventBusSettings:HostAddress"]);
                cfg.UseHealthCheck(ctx);

                cfg.ReceiveEndpoint(EventBusConstants.OrderIsDeliveredQueue, c => {
                    c.ConfigureConsumer<OrderIsDeliveredConsumer>(ctx);
                });
            });
        });
        services.AddScoped<OrderIsDeliveredConsumer>();
        services.AddMassTransitHostedService();

        return services;
    }

    private static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Koko Pizza API",
            });

            c.OperationFilter<FileResultContentTypeOperationFilter>();
        });
    }
}