using MediatR;

namespace KokoPizza.Core.Application.Features.Categories.Queries.GetCategoryList;

public class GetCategoryListQuery : IRequest<IEnumerable<CategoryListDto>>
{
    
}