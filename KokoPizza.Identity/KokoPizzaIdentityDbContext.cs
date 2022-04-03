using KokoPizza.Identity.Extensions;
using KokoPizza.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KokoPizza.Identity;

public class KokoPizzaIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
{
    public KokoPizzaIdentityDbContext(DbContextOptions<KokoPizzaIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConvertToSnakeCase();
    }
}