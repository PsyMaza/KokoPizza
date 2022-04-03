using KokoPizza.Core.Domain.Entities;

namespace KokoPizza.Core.Application.Features.Carts.Commands.CreateCart;

public class CreateCartDto
{
    public long Id { get; set; }
    
    public long UserId { get; set; }

    public List<CreateCartItemDto> Items { get; set; }
}