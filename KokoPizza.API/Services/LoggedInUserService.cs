using System.Security.Claims;
using KokoPizza.Core.Application.Contracts;

namespace KokoPizza.API.Services;

public class LoggedInUserService : ILoggedInUserService
{
    public long UserId { get; }

    public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
    {
        var userId = httpContextAccessor.HttpContext?.User?.FindFirstValue("userId");

        UserId = long.TryParse(userId, out var id) ? id : -2;
    }
}