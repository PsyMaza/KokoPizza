using KokoPizza.Core.Application.Contracts.Persistance;
using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.RemoveCartItem;

public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand>
{
    private readonly ICartRepository _cartRepository;

    public RemoveCartItemCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Unit> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
    {
        await _cartRepository.RemoveItem(request.CartItemId);
        return Unit.Value;
    }
}