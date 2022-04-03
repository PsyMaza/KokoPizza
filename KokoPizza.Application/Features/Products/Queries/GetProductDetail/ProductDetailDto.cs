namespace KokoPizza.Core.Application.Features.Products.Queries.GetProductDetail;

public class ProductDetailDto
{
    public long Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }

    public decimal Price { get; set; }

    public string PictureUri { get; set; }
    
    public long CategoryId { get; set; } 
}