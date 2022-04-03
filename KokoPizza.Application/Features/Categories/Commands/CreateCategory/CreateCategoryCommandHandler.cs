using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Entities;
using MediatR;

namespace KokoPizza.Core.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, long>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        await _repository.AddAsync(category);

        return category.Id;
    }
}