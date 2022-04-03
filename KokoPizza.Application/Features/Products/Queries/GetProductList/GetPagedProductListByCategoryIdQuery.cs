using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Queries.GetProductList;

public class GetPagedProductListByCategoryIdQuery : IRequest<PagedProductDto>
{
    public int Page { get; set; }

    public int Size { get; set; }

    public long CategoryId { get; set; }

    public GetPagedProductListByCategoryIdQuery(long categoryId, int page, int size)
    {
        Page = page;
        Size = size;
        CategoryId = categoryId;
    }
}