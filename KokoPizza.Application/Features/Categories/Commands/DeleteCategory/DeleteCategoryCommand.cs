using MediatR;

namespace KokoPizza.Core.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest
{
    public long Id { get; set; }

    public DeleteCategoryCommand(long id)
    {
        Id = id;
    }
}