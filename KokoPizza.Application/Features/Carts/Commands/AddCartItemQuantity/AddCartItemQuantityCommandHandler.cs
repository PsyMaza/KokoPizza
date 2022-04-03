using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Application.Features.Carts.Commands.AddCartItem;
using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.AddCartItemQuantity;

public class AddCartItemQuantityCommandHandler : IRequestHandler<AddCartItemQuantityCommand, int>
{
    private readonly ICartRepository _cartRepository;

    public AddCartItemQuantityCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<int> Handle(AddCartItemQuantityCommand request, CancellationToken cancellationToken)
    {
        var quantity = await _cartRepository.AddQuantity(request.CartItemId);
        return quantity;
    }
}