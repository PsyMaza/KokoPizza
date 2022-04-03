using System.ComponentModel;
using System.Runtime.CompilerServices;
using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Timer = System.Timers.Timer;

namespace KokoPizza.Blazor.Application.Pages;

public partial class OrderDetail : ComponentBase, IDisposable
{
    private CancellationTokenSource _cts = new CancellationTokenSource();
    [Inject] public IOrderDataService OrderDataService { get; set; }

    [Inject] public ICartDataService CartDataService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Parameter] public string Id { get; set; }

    public OrderViewModel OrderDetails { get; set; }

    private string status;

    public string Status
    {
        get => status;
        set => SetProperty(ref status, value);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propertyName));
    }

    bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string
        propertyName = null)
    {
        if (Equals(storage, value))
        {
            return false;
        }

        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }


    public CartViewModel UserCart { get; set; }

    [Inject] public IJSRuntime JSRuntime { get; set; }

    public string Message { get; set; }

    public bool IsNew { get; set; } = false;

    protected async override Task OnInitializedAsync()
    {
        UserCart = await CartDataService.GetUserCart();

        if (long.TryParse(Id, out var selectedOrderId))
        {
            OrderDetails = await OrderDataService.GetOrderById(selectedOrderId);
            Status = OrderDetails.StatusName;
        }
        else
        {
            IsNew = true;
            OrderDetails = new OrderViewModel
            {
                OrderItems = UserCart.Items.Select(item => new OrderItemViewModel
                {
                    Product = item.Product,
                    Quantity = item.Quantity,
                    ProductPrice = item.Product.Price
                }).ToList()
            };
        }
    }

    private async Task RefreshStatus()
    {
        var timer = new Timer();
        timer.Interval = 5000;
        timer.Elapsed += async (_, _) =>
        {
            var order = await OrderDataService.GetOrderById(OrderDetails.Id);
            Status = order.StatusName;
            StateHasChanged();
            if (!OrderDetails.StatusName.Equals("Delivering"))
                timer.Stop();
        };

        timer.Start();
    }

    protected void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/ordersOverview");
    }

    protected void AddQuantity(OrderItemViewModel orderItem)
    {
        orderItem.Quantity++;
    }

    protected void RemoveQuantity(OrderItemViewModel orderItem)
    {
        orderItem.Quantity--;
    }

    protected void RemoveItem(OrderItemViewModel orderItem)
    {
        OrderDetails.OrderItems.Remove(orderItem);
    }

    protected async Task HandleValidSubmit()
    {
        var response = await OrderDataService.CreateOrder(OrderDetails);
        HandleResponse(response);
    }

    protected async Task PayOrder()
    {
        await OrderDataService.PayOrder(OrderDetails.Id);
        OrderDetails = await OrderDataService.GetOrderById(OrderDetails.Id);
        Status = OrderDetails.StatusName;
        await RefreshStatus();
    }

    protected async Task DeclineOrder()
    {
        var response = await OrderDataService.DeclineOrder(OrderDetails.Id);
        HandleResponse(response);
    }

    private void HandleResponse<T>(ApiResponse<T> response)
    {
        if (response.Success)
        {
            NavigateToOverview();
        }
        else
        {
            Message = response.Message;
            if (!string.IsNullOrEmpty(response.ValidationErrors))
                Message += response.ValidationErrors;
        }
    }

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}