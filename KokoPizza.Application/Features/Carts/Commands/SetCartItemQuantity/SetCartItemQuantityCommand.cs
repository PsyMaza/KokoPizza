using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.SetCartItemQuantity;

public class SetCartItemQuantityCommand : IRequest<int>
{
    public long CartItemId { get; set; }

    public int Quantity { get; set; }
}