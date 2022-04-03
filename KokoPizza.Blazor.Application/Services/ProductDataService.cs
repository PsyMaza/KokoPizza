using AutoMapper;
using Blazored.LocalStorage;
using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Extensions;
using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;

namespace KokoPizza.Blazor.Application.Services;

public class ProductDataService : BaseDataService, IProductDataService
{
    private readonly IMapper _mapper;

    public ProductDataService(ILocalStorageService localStorage, IClient client, IMapper mapper)
        : base(localStorage, client)
    {
        _mapper = mapper;
    }

    public async Task<List<ProductListViewModel>> GetAllProducts()
    {
        await AddBearerToken();

        var products = await _client.GetAllProductsAsync();
        return _mapper.Map<ICollection<ProductListViewModel>>(products).ToList();
    }

    public async Task<PagedProductViewModel> GetAllProductsWithPagination(int pageNumber, int pageSize)
    {
        await AddBearerToken();

        var pagedProducts = await _client.GetAllProductsWithPaginationAsync(pageNumber, pageSize);
        return _mapper.Map<PagedProductViewModel>(pagedProducts);
    }

    public async Task<ProductDetailViewModel> GetProductById(long id)
    {
        await AddBearerToken();

        var product = await _client.GetProductByIdAsync(id);
        return _mapper.Map<ProductDetailViewModel>(product);
    }

    public async Task<ApiResponse<long>> CreateProduct(ProductDetailViewModel productDetailViewModel)
    {
        await AddBearerToken();

        var func = async () =>
        {
            var model = _mapper.Map<CreateProductCommand>(productDetailViewModel);
            await _client.AddProductAsync(model);
        };

        return await func.TrySend();
    }

    public async Task<ApiResponse<long>> UpdateProduct(ProductDetailViewModel productDetailViewModel)
    {
        await AddBearerToken();

        var func = async () =>
        {
            var updateProductCommand =
                _mapper.Map<UpdateProductCommand>(productDetailViewModel);
            await _client.UpdateProductAsync(updateProductCommand);
        };

        return await func.TrySend();
    }

    public async Task<ApiResponse<long>> DeleteProduct(long id)
    {
        await AddBearerToken();

        var func = async () =>
            await _client.DeleteProductAsync(id);
        return await func.TrySend();
    }
}