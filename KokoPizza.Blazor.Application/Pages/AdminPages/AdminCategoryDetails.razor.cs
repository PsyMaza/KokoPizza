using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace KokoPizza.Blazor.Application.Pages.AdminPages;

public partial class AdminCategoryDetails
{
    [Inject] public ICategoryDataService CategoryDataService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IJSRuntime JSRuntime { get; set; }

    [Parameter] public string Id { get; set; }

    public CategoryDetailViewModel CategoryDetails { get; set; }

    public string Message { get; set; }

    protected async override Task OnInitializedAsync()
    {
        if (long.TryParse(Id, out var selectedCategoryId))
        {
            CategoryDetails = await CategoryDataService.GetCategoryById(selectedCategoryId);
        }
        else
        {
            CategoryDetails = new CategoryDetailViewModel();
        }
    }

    protected async Task HandleValidSubmit()
    {
        if (CategoryDetails.Id == default)
        {
            var response = await CategoryDataService.CreateCategory(CategoryDetails);
            HandleResponse(response);
        }
        else
        {
            var response = await CategoryDataService.UpdateCategory(CategoryDetails);
            HandleResponse(response);
        }
    }

    protected async Task DeleteCategory()
    {
        var response = await CategoryDataService.DeleteCategory(CategoryDetails.Id);
        HandleResponse(response);
    }

    protected void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/adminCategoriesOverview");
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