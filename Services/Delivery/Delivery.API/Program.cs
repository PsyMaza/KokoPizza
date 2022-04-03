using System.Reflection;
using Delivery.API.EventBusConsumer;
using Delivery.Application;
using EventBus.Messages.Common;
using MassTransit;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDeliveryApplicationServices();

// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<OrderIsReadyConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.UseHealthCheck(ctx);

        cfg.ReceiveEndpoint(EventBusConstants.OrderIsReadyQueue,
            c => { c.ConfigureConsumer<OrderIsReadyConsumer>(ctx); });
    });
});
builder.Services.AddScoped<OrderIsReadyConsumer>();

builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();