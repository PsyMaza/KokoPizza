using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KokoPizza.Blazor.Application.Pages.AdminPages;

public partial class AdminCategoriesOverview
{
    [Inject] public ICategoryDataService CategoryDataService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    public ICollection<CategoryListViewModel> Categories { get; set; }

    [Inject] public IJSRuntime JSRuntime { get; set; }


    protected async override Task OnInitializedAsync()
    {
        Categories = await CategoryDataService.GetAllCategories();
    }

    protected void AddNewCategory()
    {
        NavigationManager.NavigateTo("./editCategory");
    }
}