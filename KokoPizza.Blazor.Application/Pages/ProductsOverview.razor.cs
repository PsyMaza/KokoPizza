using KokoPizza.Blazor.Application.Components;
using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Records;
using KokoPizza.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KokoPizza.Blazor.Application.Pages;

public partial class ProductsOverview
{
    [Inject] public IProductDataService ProductDataService { get; set; }

    [Inject] public ICartDataService CartDataService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    private int _pageNumber = 1;

    private int _pageSize = 3;

    private PaginatedList<ProductListViewModel> _paginatedList = new();

    public ICollection<ProductListViewModel> Products { get; set; }

    [Inject] public IJSRuntime JSRuntime { get; set; }


    protected async override Task OnInitializedAsync()
    {
        var pagedProducts = await ProductDataService.GetAllProductsWithPagination(_pageNumber, _pageSize);
        _paginatedList =
            new PaginatedList<ProductListViewModel>(
                new PaginatedListSettingsRecord<ProductListViewModel>(pagedProducts.Data.ToList(), pagedProducts.Count,
                    pagedProducts.Page, pagedProducts.Size));
        Products = pagedProducts.Data;
    }

    protected void NavigateToDetails()
    {
        NavigationManager.NavigateTo("details");
    }

    protected void NavigateToCart()
    {
        NavigationManager.NavigateTo("/cartOverview");
    }

    protected void AddToCart(long productId)
    {
        CartDataService.AddCartItem(productId);
    }

    public async void PageIndexChanged(int newPageNumber)
    {
        if (newPageNumber < 1 || newPageNumber > _paginatedList.Count)
        {
            return;
        }

        _pageNumber = newPageNumber;
        StateHasChanged();
    }
}