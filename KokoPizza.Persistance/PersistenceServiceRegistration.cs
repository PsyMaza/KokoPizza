using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Persistance.Context;
using KokoPizza.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KokoPizza.Infrastructure.Persistance;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<KokoPizzaDbContext>(options =>
            options.UseNpgsql(connectionString, builder => builder.MigrationsAssembly("KokoPizza.Persistance"))
                .UseSnakeCaseNamingConvention()
        );

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}