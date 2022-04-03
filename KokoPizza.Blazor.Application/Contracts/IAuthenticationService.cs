using KokoPizza.Blazor.Application.Records;

namespace KokoPizza.Blazor.Application.Contracts;

public interface IAuthenticationService
{
    Task<bool> Authenticate(AuthUserRecord user);
    Task<bool> Register(RegisterUserRecord user);
    Task Logout(); 
}