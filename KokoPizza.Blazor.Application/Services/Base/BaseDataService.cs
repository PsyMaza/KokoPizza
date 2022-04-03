using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace KokoPizza.Blazor.Application.Services.Base;

public abstract class BaseDataService
{
    protected readonly ILocalStorageService _localStorage;

    protected IClient _client;

    protected BaseDataService(ILocalStorageService localStorage, IClient client)
    {
        _localStorage = localStorage;
        _client = client;
    }

    protected async Task AddBearerToken()
    {
        if (await _localStorage.ContainKeyAsync("token"))
            _client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
    }
}