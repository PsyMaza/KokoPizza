using AutoMapper;
using KokoPizza.Core.Application.Features.Carts.Queries.GetUserCart;
using KokoPizza.Core.Application.Features.Categories.Commands.CreateCategory;
using KokoPizza.Core.Application.Features.Categories.Commands.UpdateCategory;
using KokoPizza.Core.Application.Features.Categories.Queries.GetCategoryDetail;
using KokoPizza.Core.Application.Features.Categories.Queries.GetCategoryList;
using KokoPizza.Core.Application.Features.Orders.Queries.DTOs;
using KokoPizza.Core.Application.Features.Products.Commands.CreateProduct;
using KokoPizza.Core.Application.Features.Products.Commands.UpdateProduct;
using KokoPizza.Core.Application.Features.Products.Queries.GetProductDetail;
using KokoPizza.Core.Application.Features.Products.Queries.GetProductList;
using KokoPizza.Core.Domain.Entities;
using KokoPizza.Core.Domain.Enums;

namespace KokoPizza.Core.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        RegisterProducts();
        RegisterCategories();
        RegisterCart();
        RegisterOrder();
    }

    private void RegisterCategories()
    {
        CreateMap<Category, CategoryListDto>().ReverseMap();
        CreateMap<Category, CategoryDetailDto>().ReverseMap();
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
    }

    private void RegisterProducts()
    {
        CreateMap<Product, ProductListDto>().ReverseMap();
        CreateMap<Product, ProductDetailDto>().ReverseMap();
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, UpdateProductCommand>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
    }

    private void RegisterCart()
    {
        CreateMap<Cart, UserCartDto>().ReverseMap();
        CreateMap<CartItem, UserCartItemDto>().ReverseMap();
    }

    private void RegisterOrder()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(
                dest => dest.StatusName,
                opt => opt.MapFrom(source => source.StatusId)
            )
            .ForMember(
                dest => dest.OrderItems,
                opt => opt.MapFrom(source => source.Items)
            )
            .ReverseMap();
        CreateMap<OrderItem, GetOrderItemDto>().ReverseMap();
        CreateMap<OrderStatus, string>().ConvertUsing(src => src.ToString());
    }
}