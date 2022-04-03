using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Queries.GetProductList;

public class
    GetPagedProductListByCategoryIdQueryHandler : IRequestHandler<GetPagedProductListByCategoryIdQuery, PagedProductDto>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetPagedProductListByCategoryIdQueryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedProductDto> Handle(GetPagedProductListByCategoryIdQuery request,
        CancellationToken cancellationToken)
    {
        var list = await _repository.GetPagedProductsByCategoryId(request.CategoryId, request.Page, request.Size);
        var products = _mapper.Map<List<ProductListDto>>(list);

        var count = await _repository.GetCountOfProductsByCategoryId(request.CategoryId);

        return new PagedProductDto
        {
            Count = count,
            Data = products,
            Page = request.Page,
            Size = request.Size
        };
    }
}