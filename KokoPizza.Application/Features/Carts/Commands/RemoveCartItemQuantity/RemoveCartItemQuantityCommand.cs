using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.RemoveCartItemQuantity;

public class RemoveCartItemQuantityCommand : IRequest<int>
{
    public long CartItemId { get; set; }
}