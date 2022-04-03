using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;

namespace KokoPizza.Blazor.Application.Contracts;

public interface IProductDataService
{
    Task<List<ProductListViewModel>> GetAllProducts();

    Task<PagedProductViewModel> GetAllProductsWithPagination(int pageNumber, int pageSize);

    Task<ProductDetailViewModel> GetProductById(long id);

    Task<ApiResponse<long>> CreateProduct(ProductDetailViewModel productDetailViewModel);

    Task<ApiResponse<long>> UpdateProduct(ProductDetailViewModel productDetailViewModel);

    Task<ApiResponse<long>> DeleteProduct(long id);
}