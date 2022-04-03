namespace KokoPizza.Blazor.Application.ViewModels;

public class CartViewModel
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public virtual List<CartItemViewModel> Items { get; set; }
}