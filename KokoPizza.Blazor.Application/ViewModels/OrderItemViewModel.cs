namespace KokoPizza.Blazor.Application.ViewModels;

public sealed record OrderItemViewModel
{
    public long Id { get; set; }
    public int Quantity { get; set; }
    public decimal ProductPrice { get; set; }
    public ProductListViewModel Product { get; set; } = new ProductListViewModel();
}