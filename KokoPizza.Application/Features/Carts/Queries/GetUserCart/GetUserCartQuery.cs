using MediatR;

namespace KokoPizza.Core.Application.Features.Carts.Queries.GetUserCart;

public class GetUserCartQuery : IRequest<UserCartDto>
{
}