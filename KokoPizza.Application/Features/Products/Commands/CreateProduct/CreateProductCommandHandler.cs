using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Entities;
using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : AsyncRequestHandler<CreateProductCommand>
{
    private readonly IAsyncRepository<Product> _repository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IAsyncRepository<Product> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    protected override async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        await _repository.AddAsync(product);
    }
}