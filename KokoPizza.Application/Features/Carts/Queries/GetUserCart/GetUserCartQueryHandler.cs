using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Queries.GetUserCart;

public class GetUserCartQueryHandler : IRequestHandler<GetUserCartQuery, UserCartDto>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public GetUserCartQueryHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UserCartDto> Handle(GetUserCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetUserCart();
        return _mapper.Map<UserCartDto>(cart);
    }
}