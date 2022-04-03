using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.AddCartItemQuantity;

public class AddCartItemQuantityCommand : IRequest<int>
{
    public long CartItemId { get; set; }
}