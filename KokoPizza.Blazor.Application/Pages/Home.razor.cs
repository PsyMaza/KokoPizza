using KokoPizza.Blazor.Application.Auth;
using KokoPizza.Blazor.Application.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace KokoPizza.Blazor.Application.Pages;

public partial class Home
{
    [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IAuthenticationService AuthenticationService { get; set; }

    protected async override Task OnInitializedAsync()
    {
        await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
    }

    protected void NavigateToLogin()
    {
        NavigationManager.NavigateTo("login");
    }

    protected void NavigateToRegister()
    {
        NavigationManager.NavigateTo("register");
    }

    protected async void Logout()
    {
        await AuthenticationService.Logout();
    }
}