using MediatR;

namespace KokoPizza.Core.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string PictureUri { get; set; }

    public long CategoryId { get; set; }
}