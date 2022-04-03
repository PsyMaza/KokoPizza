using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KokoPizza.Blazor.Application.Pages.AdminPages;

public partial class AdminProductDetails
{
    [Inject] public IProductDataService ProductDataService { get; set; }

    [Inject] public ICategoryDataService CategoryDataService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IJSRuntime JSRuntime { get; set; }

    [Parameter] public string Id { get; set; }

    public ProductDetailViewModel ProductDetails { get; set; }

    public ICollection<CategoryListViewModel> Categories { get; set; }

    public string Message { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Categories = await CategoryDataService.GetAllCategories();

        if (long.TryParse(Id, out var selectedProductId))
        {
            ProductDetails = await ProductDataService.GetProductById(selectedProductId);
        }
        else
        {
            ProductDetails = new ProductDetailViewModel();
        }
    }

    protected async Task HandleValidSubmit()
    {
        if (ProductDetails.Id == default)
        {
            var response = await ProductDataService.CreateProduct(ProductDetails);
            HandleResponse(response);
        }
        else
        {
            var response = await ProductDataService.UpdateProduct(ProductDetails);
            HandleResponse(response);
        }
    }

    protected async Task DeleteProduct()
    {
        var response = await ProductDataService.DeleteProduct(ProductDetails.Id);
        HandleResponse(response);
    }

    protected void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/adminProductsOverview");
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
}