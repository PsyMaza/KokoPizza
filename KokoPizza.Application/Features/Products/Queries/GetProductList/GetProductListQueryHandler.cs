using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Entities;
using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Queries.GetProductList;

public class GetProductListQueryListHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductListDto>>
{
    private readonly IAsyncRepository<Product> _repository;
    private readonly IMapper _mapper;

    public GetProductListQueryListHandler(IAsyncRepository<Product> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<ProductListDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var products = (await _repository.ListAllAsync())
            .OrderBy(e => e.CategoryId)
            .ThenBy(e => e.Name)
            .ThenBy(e => e.CreatedDate);
        
        return _mapper.Map<List<ProductListDto>>(products);
    }
}