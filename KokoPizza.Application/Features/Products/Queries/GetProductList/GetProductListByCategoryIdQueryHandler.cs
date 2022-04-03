using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Entities;
using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Queries.GetProductList;

public class
    GetProductListByCategoryIdQueryHandler : IRequestHandler<GetProductListByCategoryIdQuery, IEnumerable<ProductListDto>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductListByCategoryIdQueryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<ProductListDto>> Handle(GetProductListByCategoryIdQuery request,
        CancellationToken cancellationToken)
    {
        var products = (await _repository.GetProductsByCategoryId(request.CategoryId))
            .OrderBy(e => e.CategoryId)
            .ThenBy(e => e.Name)
            .ThenBy(e => e.CreatedDate);

        return _mapper.Map<List<ProductListDto>>(products);
    }
}