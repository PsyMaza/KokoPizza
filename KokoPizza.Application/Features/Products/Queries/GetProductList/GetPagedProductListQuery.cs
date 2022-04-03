using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Queries.GetProductList;

public class GetPagedProductListQuery : IRequest<PagedProductDto>
{
    public int Page { get; set; }

    public int Size { get; set; }

    public GetPagedProductListQuery(int page, int size)
    {
        Page = page;
        Size = size;
    }
}