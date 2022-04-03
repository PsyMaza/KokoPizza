using KokoPizza.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KokoPizza.Persistance.Context.Configurations;

public static class CartConfigurations
{
    public static ModelBuilder AddCartConfiguration(this ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new CartConfiguration())
            .ApplyConfiguration(new CartItemConfiguration());

        return builder;
    }

    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.UserId).IsUnique();
        }
    }

    internal class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Cart)
                .WithMany(e => e.Items)
                .HasPrincipalKey(e => e.Id)
                .HasForeignKey(e => e.CartId);
        }
    }
}