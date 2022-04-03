using AutoMapper;
using Blazored.LocalStorage;
using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Extensions;
using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;

namespace KokoPizza.Blazor.Application.Services;

public class CartDataService : BaseDataService, ICartDataService
{
    private readonly IMapper _mapper;

    public CartDataService(ILocalStorageService localStorage, IClient client, IMapper mapper)
        : base(localStorage, client)
    {
        _mapper = mapper;
    }

    public async Task<CartViewModel> GetUserCart()
    {
        await AddBearerToken();

        var userCart = await _client.GetUserCartAsync();
        return _mapper.Map<CartViewModel>(userCart);
    }

    public async Task<ApiResponse<long>> CreateCart(CartViewModel cart)
    {
        await AddBearerToken();

        var func = async () =>
        {
            var model = _mapper.Map<CreateCartCommand>(cart);
            await _client.CreateUserCartAsync(model);
        };

        return await func.TrySend();
    }

    public async Task<ApiResponse<long>> AddCartItem(long productId, int quantity = 1)
    {
        await AddBearerToken();

        var func = async () => { await _client.AddCartItemAsync(productId, quantity); };

        return await func.TrySend();
    }

    public async Task<ApiResponse<int>> AddQuantity(long cartItemId)
    {
        await AddBearerToken();

        var func = async () => await _client.AddQuantityAsync(cartItemId);

        return await func.TrySend();
    }

    public async Task<ApiResponse<int>> RemoveQuantity(long cartItemId)
    {
        await AddBearerToken();

        var func = async () => await _client.RemoveQuantityAsync(cartItemId);

        return await func.TrySend();
    }

    public async Task<ApiResponse<long>> RemoveCartItem(long cartItemId)
    {
        await AddBearerToken();

        var func = async () => await _client.CartAsync(cartItemId);

        return await func.TrySend();
    }
}