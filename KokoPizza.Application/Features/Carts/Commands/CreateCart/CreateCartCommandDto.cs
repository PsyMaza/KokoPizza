using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Entities;
using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.CreateCart;

public class CreateCartCommandDto : IRequestHandler<CreateCartCommand, CreateCartDto>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public CreateCartCommandDto(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<CreateCartDto> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = _mapper.Map<Cart>(request);
        cart = await _cartRepository.AddAsync(cart);

        return _mapper.Map<CreateCartDto>(cart);
    }
}