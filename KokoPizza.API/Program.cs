using KokoPizza.API;
using KokoPizza.API.Middleware;
using KokoPizza.Core.Application;
using KokoPizza.Identity;
using KokoPizza.Infrastructure.Infrastructure;
using KokoPizza.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiServices(builder.Configuration)
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddPersistenceServices(builder.Configuration)
    .AddIdentityServices(builder.Configuration);

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddCors(options =>
    {
        options.AddPolicy("Open", builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
        );
    }
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCustomExceptionHandler()
    .UseHttpsRedirection()
    .UseRouting()
    .UseCors("Open")
    .UseAuthentication()
    .UseAuthorization()
    .UseSwagger()
    .UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Koko Pizza API"))
    .UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();