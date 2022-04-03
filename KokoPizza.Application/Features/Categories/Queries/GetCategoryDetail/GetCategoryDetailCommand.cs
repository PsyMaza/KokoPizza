using MediatR;

namespace KokoPizza.Core.Application.Features.Categories.Queries.GetCategoryDetail;

public class GetCategoryDetailQuery : IRequest<CategoryDetailDto>
{
    public long Id { get; set; }

    public GetCategoryDetailQuery(long id)
    {
        Id = id;
    }
}