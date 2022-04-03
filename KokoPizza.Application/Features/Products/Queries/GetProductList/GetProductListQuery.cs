using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Queries.GetProductList;

public class GetProductListQuery : IRequest<IEnumerable<ProductListDto>>
{
    
}