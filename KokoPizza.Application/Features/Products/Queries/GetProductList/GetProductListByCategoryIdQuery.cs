using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Queries.GetProductList;

public class GetProductListByCategoryIdQuery : IRequest<IEnumerable<ProductListDto>>
{
    public long CategoryId { get; }

    public GetProductListByCategoryIdQuery(long categoryId)
    {
        CategoryId = categoryId;
    }
}