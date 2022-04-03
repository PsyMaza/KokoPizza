namespace KokoPizza.Blazor.Application.Services.Base;

public partial interface IClient
{
    public HttpClient HttpClient { get; }
}