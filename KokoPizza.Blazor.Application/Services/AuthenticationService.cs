using System.Net.Http.Headers;
using Blazored.LocalStorage;
using KokoPizza.Blazor.Application.Auth;
using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Records;
using KokoPizza.Blazor.Application.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace KokoPizza.Blazor.Application.Services;

public class AuthenticationService : BaseDataService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(ILocalStorageService localStorage, IClient client,
        AuthenticationStateProvider authenticationStateProvider) : base(localStorage, client)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> Authenticate(AuthUserRecord user)
    {
        try
        {
            var authRequest = new AuthenticationRequest { Email = user.Email, Password = user.Password };
            var authResponse = await _client.AuthenticateAsync(authRequest);
            
            if (string.IsNullOrWhiteSpace(authResponse.Token))
                return false;

            await _localStorage.SetItemAsStringAsync("token", authResponse.Token);
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(user.Email);
            _client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", authResponse.Token);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Register(RegisterUserRecord user)
    {
        var registerRequest = new RegistrationRequest
        {
            Email = user.Email,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName
        };

        var registerResponse = await _client.RegisterAsync(registerRequest);

        if (registerResponse.UserId == default)
            return false;

        return true;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("token");
        ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
        _client.HttpClient.DefaultRequestHeaders.Authorization = null;
    }
}