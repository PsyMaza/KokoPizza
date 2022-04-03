using KokoPizza.Core.Application.Contracts.Persistance;
using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.RemoveCartItemQuantity;

public class RemoveCartItemQuantityCommandHandler : IRequestHandler<RemoveCartItemQuantityCommand, int>
{
    private readonly ICartRepository _cartRepository;

    public RemoveCartItemQuantityCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<int> Handle(RemoveCartItemQuantityCommand request, CancellationToken cancellationToken)
    {
        var quantity = await _cartRepository.RemoveQuantity(request.CartItemId);
        return quantity;
    }
}