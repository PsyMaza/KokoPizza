using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KokoPizza.Blazor.Application.Pages.AdminPages;

public partial class AdminProductsOverview
{
    [Inject] public IProductDataService ProductDataService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    public ICollection<ProductListViewModel> Products { get; set; }

    [Inject] public IJSRuntime JSRuntime { get; set; }


    protected async override Task OnInitializedAsync()
    {
        Products = await ProductDataService.GetAllProducts();
    }

    protected void AddNewProduct()
    {
        NavigationManager.NavigateTo("./editProduct");
    } 
}