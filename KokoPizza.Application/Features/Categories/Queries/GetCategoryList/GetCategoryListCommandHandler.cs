using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using MediatR;

namespace KokoPizza.Core.Application.Features.Categories.Queries.GetCategoryList;

public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IEnumerable<CategoryListDto>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetCategoryListQueryHandler(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryListDto>> Handle(GetCategoryListQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await _repository.ListAllAsync();
        return _mapper.Map<List<CategoryListDto>>(categories);
    }
}