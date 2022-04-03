using AutoMapper;
using Blazored.LocalStorage;
using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Extensions;
using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;

namespace KokoPizza.Blazor.Application.Services;

public class OrderDataService : BaseDataService, IOrderDataService
{
    private readonly IMapper _mapper;

    public OrderDataService(ILocalStorageService localStorage, IClient client, IMapper mapper) : base(localStorage,
        client)
    {
        _mapper = mapper;
    }

    public async Task<ICollection<OrderViewModel>> GetAllOrders()
    {
        await AddBearerToken();

        var orders = await _client.GetOrdersAsync();
        return _mapper.Map<ICollection<OrderViewModel>>(orders);
    }

    public async Task<OrderViewModel> GetOrderById(long id)
    {
        await AddBearerToken();

        var orders = await _client.GetOrderDetailAsync(id);
        return _mapper.Map<OrderViewModel>(orders);
    }

    public async Task<ApiResponse<long>> CreateOrder(OrderViewModel orderViewModel)
    {
        await AddBearerToken();

        var func = async () =>
        {
            var model = _mapper.Map<CreateOrderModel>(orderViewModel);
            await _client.CreateOrderAsync(model);
        };

        return await func.TrySend();
    }

    public async Task<ApiResponse<long>> PayOrder(long id)
    {
        await AddBearerToken();

        var func = async () => await _client.PayOrderAsync(id);

        return await func.TrySend();
    }

    public async Task<ApiResponse<long>> CompleteOrder(long id)
    {
        await AddBearerToken();

        var func = async () => await _client.CompleteOrderAsync(id);

        return await func.TrySend();
    }

    public async Task<ApiResponse<long>> DeclineOrder(long id)
    {
        await AddBearerToken();

        var func = async () => await _client.DeclineOrderAsync(id);

        return await func.TrySend();
    }
}