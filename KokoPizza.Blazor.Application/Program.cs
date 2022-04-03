using System.Reflection;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using KokoPizza.Blazor.Application;
using KokoPizza.Blazor.Application.Auth;
using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Services;
using KokoPizza.Blazor.Application.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddAutoMapper(Assembly.GetExecutingAssembly())
    .AddBlazoredLocalStorage()
    .AddAuthorizationCore();

builder.Services
    .AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>()
    .AddScoped<IProductDataService, ProductDataService>()
    .AddScoped<ICategoryDataService, CategoryDataService>()
    .AddScoped<ICartDataService, CartDataService>()
    .AddScoped<IOrderDataService, OrderDataService>()
    .AddScoped<IAuthenticationService, AuthenticationService>()
    .AddSingleton(sp => new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7246")
    })
    .AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7246"));

await builder.Build().RunAsync();