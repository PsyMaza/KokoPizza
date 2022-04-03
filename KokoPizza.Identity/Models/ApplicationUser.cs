using Microsoft.AspNetCore.Identity;

namespace KokoPizza.Identity.Models;

public class ApplicationUser : IdentityUser<long>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}