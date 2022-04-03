using MediatR;

namespace KokoPizza.Core.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest
{
    public long Id { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }
}