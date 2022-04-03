using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;

namespace KokoPizza.Blazor.Application.Contracts;

public interface ICartDataService
{
    Task<CartViewModel> GetUserCart();

    Task<ApiResponse<long>> CreateCart(CartViewModel cart);

    Task<ApiResponse<long>> AddCartItem(long productId, int quantity = 1);

    Task<ApiResponse<int>> AddQuantity(long cartItemId);

    Task<ApiResponse<int>> RemoveQuantity(long cartItemId);
    Task<ApiResponse<long>> RemoveCartItem(long cartItemId);
}