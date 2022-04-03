using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest
{ 
    public long Id { get; set; }
}