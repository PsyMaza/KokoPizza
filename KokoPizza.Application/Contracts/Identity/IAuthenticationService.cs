using KokoPizza.Core.Application.Models.Authentication;

namespace KokoPizza.Core.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request); 
}