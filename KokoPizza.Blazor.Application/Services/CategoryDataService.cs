using AutoMapper;
using Blazored.LocalStorage;
using KokoPizza.Blazor.Application.Contracts;
using KokoPizza.Blazor.Application.Extensions;
using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;

namespace KokoPizza.Blazor.Application.Services;

public class CategoryDataService : BaseDataService, ICategoryDataService
{
    private readonly IMapper _mapper;

    public CategoryDataService(ILocalStorageService localStorage, IClient client, IMapper mapper) : base(localStorage,
        client)
    {
        _mapper = mapper;
    }

    public async Task<List<CategoryListViewModel>> GetAllCategories()
    {
        await AddBearerToken();

        var categories = await _client.GetAllCategoriesAsync();
        return _mapper.Map<ICollection<CategoryListViewModel>>(categories).ToList();
    }

    public async Task<CategoryDetailViewModel> GetCategoryById(long id)
    {
        var category = await _client.GetCategoryByIdAsync(id);
        return _mapper.Map<CategoryDetailViewModel>(category);
    }

    public async Task<ApiResponse<long>> CreateCategory(CategoryDetailViewModel categoryDetailViewModel)
    {
        await AddBearerToken();

        var func = async () =>
        {
            var model = _mapper.Map<CreateCategoryCommand>(categoryDetailViewModel);
            await _client.AddCategoryAsync(model);
        };

        return await func.TrySend();
    }

    public async Task<ApiResponse<long>> UpdateCategory(CategoryDetailViewModel categoryDetailViewModel)
    {
        await AddBearerToken();
        
        var func = async () =>
        {
            var updateCategoryCommand =
                _mapper.Map<UpdateCategoryCommand>(categoryDetailViewModel);
            await _client.UpdateCategoryAsync(updateCategoryCommand);
        };

        return await func.TrySend();
    }

    public async Task<ApiResponse<long>> DeleteCategory(long id)
    { 
        await AddBearerToken();
        
        var func = async () =>
            await _client.DeleteCategoryAsync(id);
        return await func.TrySend();
    }
}