namespace KokoPizza.Core.Application.Features.Carts.Commands.CreateCart;

public class CreateCartItemDto
{
    public int Quantity { get; set; }

    public long ProductId { get; set; }
}