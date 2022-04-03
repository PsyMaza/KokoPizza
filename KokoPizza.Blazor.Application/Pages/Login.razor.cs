using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Records;
using KokoPizza.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Components;

namespace KokoPizza.Blazor.Application.Pages;

public partial class Login
{
    public LoginViewModel LoginViewModel { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }
    public string Message { get; set; }

    [Inject] private IAuthenticationService AuthenticationService { get; set; }

    public Login()
    {
    }

    protected override void OnInitialized()
    {
        LoginViewModel = new LoginViewModel();
    }

    protected async void HandleValidSubmit()
    {
        if (await AuthenticationService.Authenticate(new AuthUserRecord(LoginViewModel.Email, LoginViewModel.Password)))
        {
            NavigationManager.NavigateTo("home");
        }

        Message = "Username/password combination unknown";
    }

    protected void NavigateToHome()
    {
        NavigationManager.NavigateTo("/home");
    }
}