using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Queries.GetProductList;

public class GetPagedProductListQueryHandler
    : IRequestHandler<GetPagedProductListQuery, PagedProductDto>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetPagedProductListQueryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<PagedProductDto> Handle(GetPagedProductListQuery request,
        CancellationToken cancellationToken)
    {
        var list = await _repository.GetPagedProducts(request.Page, request.Size);
        var products = _mapper.Map<List<ProductListDto>>(list);

        var count = await _repository.GetTotalCountOfProducts();
        return new PagedProductDto
        {
            Count = count,
            Data = products,
            Page = request.Page,
            Size = request.Size
        };
    }
}