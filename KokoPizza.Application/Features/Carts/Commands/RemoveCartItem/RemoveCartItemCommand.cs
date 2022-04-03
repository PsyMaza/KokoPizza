using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.RemoveCartItem;

public class RemoveCartItemCommand : IRequest
{
    public long CartItemId { get; set; }
}