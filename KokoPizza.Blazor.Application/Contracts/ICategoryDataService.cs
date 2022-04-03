using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;

namespace KokoPizza.Blazor.Application.Contracts;

public interface ICategoryDataService
{
    Task<List<CategoryListViewModel>> GetAllCategories();

    Task<CategoryDetailViewModel> GetCategoryById(long id);

    Task<ApiResponse<long>> CreateCategory(CategoryDetailViewModel categoryDetailViewModel);

    Task<ApiResponse<long>> UpdateCategory(CategoryDetailViewModel categoryDetailViewModel);

    Task<ApiResponse<long>> DeleteCategory(long id);
}