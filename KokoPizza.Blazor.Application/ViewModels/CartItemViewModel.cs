namespace KokoPizza.Blazor.Application.ViewModels;

public class CartItemViewModel
{
    public long Id { get; set; }

    public long CartId { get; set; }

    public int Quantity { get; set; }

    public long ProductId { get; set; }

    public virtual ProductListViewModel Product { get; set; }
}