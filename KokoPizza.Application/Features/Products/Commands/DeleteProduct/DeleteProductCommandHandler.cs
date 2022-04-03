using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Application.Exceptions;
using KokoPizza.Core.Domain.Entities;
using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : AsyncRequestHandler<DeleteProductCommand>
{
    private readonly IAsyncRepository<Product> _repository;
    private readonly IMapper _mapper;

    public DeleteProductCommandHandler(IAsyncRepository<Product> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    protected override async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
            throw new NotFoundException(nameof(Product), request.Id);

        await _repository.DeleteAsync(product);
    }
}