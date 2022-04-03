using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Records;
using KokoPizza.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Components;

namespace KokoPizza.Blazor.Application.Pages;

public partial class Register
{
    public RegisterViewModel RegisterViewModel { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    public string Message { get; set; }

    [Inject] private IAuthenticationService AuthenticationService { get; set; }

    public Register()
    {
    }

    protected override void OnInitialized()
    {
        RegisterViewModel = new RegisterViewModel();
    }

    protected async void HandleValidSubmit()
    {
        var result = await AuthenticationService.Register(new RegisterUserRecord(RegisterViewModel.FirstName,
            RegisterViewModel.LastName,
            RegisterViewModel.UserName, RegisterViewModel.Email, RegisterViewModel.Password));

        if (result)
        {
            NavigationManager.NavigateTo("/home");
        }

        Message = "Something went wrong, please try again.";
    }
    
    protected void NavigateToHome()
    {
        NavigationManager.NavigateTo("/home");
    }
}