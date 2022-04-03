using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.AddCartItem;

public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, long>
{
    private readonly ICartRepository _cartRepository;

    public AddCartItemCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<long> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        return await _cartRepository.AddItem(request.ProductId, request.Quantity);
    }
}