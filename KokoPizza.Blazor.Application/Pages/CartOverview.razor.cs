using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KokoPizza.Blazor.Application.Pages;

public partial class CartOverview
{
    [Inject] public ICartDataService CartDataService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    public CartViewModel UserCart { get; set; }

    [Inject] public IJSRuntime JSRuntime { get; set; }

    protected async override Task OnInitializedAsync()
    {
        UserCart = await CartDataService.GetUserCart();
    }

    protected void NavigateToProducts()
    {
        NavigationManager.NavigateTo("/productsOverview");
    }

    protected void NavigateToOrder()
    {
        NavigationManager.NavigateTo("/orderDetails");
    }

    protected async Task AddQuantity(CartItemViewModel cartItem)
    {
        var response = await CartDataService.AddQuantity(cartItem.Id);
        cartItem.Quantity = response.Data;
    }

    protected async Task RemoveQuantity(CartItemViewModel cartItem)
    {
        var response = await CartDataService.RemoveQuantity(cartItem.Id);
        cartItem.Quantity = response.Data;
        if (cartItem.Quantity < 1)
            await RemoveCartItem(cartItem);
    }

    protected async Task RemoveCartItem(CartItemViewModel cartItem)
    {
        await CartDataService.RemoveCartItem(cartItem.Id);
        UserCart.Items.Remove(cartItem);
    }
}