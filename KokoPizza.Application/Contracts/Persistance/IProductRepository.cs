using KokoPizza.Core.Domain.Entities;

namespace KokoPizza.Core.Application.Contracts.Persistance;

public interface IProductRepository : IAsyncRepository<Product>
{
    Task<IReadOnlyList<Product>> GetProductsByCategoryId(long categoryId);

    Task<IReadOnlyList<Product>> GetPagedProductsByCategoryId(long categoryId, int page, int size);

    Task<IReadOnlyList<Product>> GetPagedProducts(int page, int size);

    Task<int> GetCountOfProductsByCategoryId(long categoryId);
    
    Task<int> GetTotalCountOfProducts();
}