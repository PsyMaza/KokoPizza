namespace KokoPizza.Blazor.Application.ViewModels;

public class ProductDetailViewModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string PictureUri { get; set; }

    public long CategoryId { get; set; }
}