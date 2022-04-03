using MediatR;

namespace KokoPizza.Core.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<long>
{
    public string Name { get; set; }

    public string Description { get; set; }
}