using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.AddCartItem;

public class AddCartItemCommand : IRequest<long>
{
    public long ProductId { get; set; }
    
    public int Quantity { get; set; }
}