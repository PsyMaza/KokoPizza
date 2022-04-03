using KokoPizza.Core.Domain.Entities;

namespace KokoPizza.Core.Application.Features.Carts.Queries.GetUserCart;

public class UserCartDto
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public virtual List<UserCartItemDto> Items { get; set; }
}

public class UserCartItemDto
{
    public long Id { get; set; }

    public long CartId { get; set; }

    public int Quantity { get; set; }

    public long ProductId { get; set; }

    public virtual ProductDto Product { get; set; }
}

public class ProductDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string PictureUri { get; set; }

    public long CategoryId { get; set; }
}