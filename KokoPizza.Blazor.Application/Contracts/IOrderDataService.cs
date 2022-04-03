using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;

namespace KokoPizza.Blazor.Application.Contracts;

public interface IOrderDataService
{
    Task<ICollection<OrderViewModel>> GetAllOrders();

    Task<OrderViewModel> GetOrderById(long id);

    Task<ApiResponse<long>> CreateOrder(OrderViewModel orderViewModel);

    Task<ApiResponse<long>> PayOrder(long id);
    
    Task<ApiResponse<long>> CompleteOrder(long id);

    Task<ApiResponse<long>> DeclineOrder(long id);
}