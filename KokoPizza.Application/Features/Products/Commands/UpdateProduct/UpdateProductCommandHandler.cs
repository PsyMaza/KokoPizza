using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Application.Exceptions;
using KokoPizza.Core.Domain.Entities;
using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : AsyncRequestHandler<UpdateProductCommand>
{
    private readonly IAsyncRepository<Product> _repository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IAsyncRepository<Product> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    protected override async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
            throw new NotFoundException(nameof(Product), request.Id);

        _mapper.Map(request, product, typeof(UpdateProductCommand),
            typeof(Product));

        await _repository.UpdateAsync(product);
    }
}