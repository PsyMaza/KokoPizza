using AutoMapper;
using KokoPizza.Blazor.Application.Services.Base;
using KokoPizza.Blazor.Application.ViewModels;

namespace KokoPizza.Blazor.Application.Profiles;

public class Mappings : Profile
{
    public Mappings()
    {
        RegisterCartViewModel();
        RegisterProductsViewModel();
        RegisterCategoryViewModel();
        RegisterOrderViewModel();
    }

    private void RegisterProductsViewModel()
    {
        CreateMap<ProductDto, ProductListViewModel>().ReverseMap();
        CreateMap<ProductListDto, ProductListViewModel>().ReverseMap();
        CreateMap<ProductDetailDto, ProductDetailViewModel>().ReverseMap();
        CreateMap<UpdateProductCommand, ProductDetailViewModel>().ReverseMap();
        CreateMap<CreateProductCommand, ProductDetailViewModel>().ReverseMap();
        CreateMap<PagedProductDto, PagedProductViewModel>().ReverseMap();
    }

    private void RegisterCategoryViewModel()
    {
        CreateMap<CategoryListDto, CategoryListViewModel>().ReverseMap();
        CreateMap<CategoryDetailDto, CategoryDetailViewModel>().ReverseMap();
        CreateMap<UpdateCategoryCommand, CategoryDetailViewModel>().ReverseMap();
        CreateMap<CreateCategoryCommand, CategoryDetailViewModel>().ReverseMap();
    }

    private void RegisterCartViewModel()
    {
        CreateMap<UserCartDto, CartViewModel>().ReverseMap();
        CreateMap<UserCartItemDto, CartItemViewModel>().ReverseMap();
    }

    private void RegisterOrderViewModel()
    {
        CreateMap<OrderDto, OrderViewModel>().ReverseMap();
        CreateMap<GetOrderItemDto, OrderItemViewModel>().ReverseMap();
        CreateMap<CreateOrderModel, OrderViewModel>().ReverseMap();
        CreateMap<CreateOrderItemDto, OrderItemViewModel>().ReverseMap();
    }
}