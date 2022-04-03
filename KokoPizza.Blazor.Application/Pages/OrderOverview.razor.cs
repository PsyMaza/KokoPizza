using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KokoPizza.Blazor.Application.Pages;

public partial class OrderOverview : IDisposable
{
    private CancellationTokenSource _cts = new CancellationTokenSource();
    [Inject] public IOrderDataService OrderDataService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    public ICollection<OrderViewModel> Orders { get; set; }

    [Inject] public IJSRuntime JSRuntime { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Orders = await OrderDataService.GetAllOrders();

        Orders.Where(order => order.StatusName.Equals("Delivering")).ToList().ForEach(order =>
            Task.Run(() => RefreshStatus(order)));
    }

    private async Task RefreshStatus(OrderViewModel order)
    {
        while (!_cts.IsCancellationRequested)
        {
            var receivedOrder = await OrderDataService.GetOrderById(order.Id);
            order.StatusName = receivedOrder.StatusName;
            if (!order.StatusName.Equals("Delivering"))
                break;
            await Task.Delay(5000);
        }
    }

    protected void NavigateToCart()
    {
        NavigationManager.NavigateTo("/cartOverview");
    }

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}