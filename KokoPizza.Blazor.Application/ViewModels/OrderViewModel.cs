namespace KokoPizza.Blazor.Application.ViewModels;

public class OrderViewModel
{
    public long Id { get; set; }

    public string StatusName { get; set; }

    public ICollection<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();

    public string ShipAddress { get; set; }

    public string PhoneNumber { get; set; }
}