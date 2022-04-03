using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Queries.GetProductDetail;

public class GetProductDetailQuery : IRequest<ProductDetailDto>
{
    public long Id { get; set; }
}