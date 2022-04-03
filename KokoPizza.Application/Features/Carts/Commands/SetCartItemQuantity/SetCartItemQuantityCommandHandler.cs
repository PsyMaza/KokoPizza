using KokoPizza.Core.Application.Contracts.Persistance;
using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.SetCartItemQuantity;

public class SetCartItemQuantityCommandHandler : IRequestHandler<SetCartItemQuantityCommand, int>
{
    private readonly ICartRepository _cartRepository;

    public SetCartItemQuantityCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<int> Handle(SetCartItemQuantityCommand request, CancellationToken cancellationToken)
    {
        var quantity = await _cartRepository.SetQuantity(request.CartItemId, request.Quantity);
        return quantity;
    }
}