using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Commands.CreateCart;

public class CreateCartCommand : IRequest<CreateCartDto>
{
    public long UserId { get; set; }

    public List<CreateCartItemDto> Items { get; set; }
}