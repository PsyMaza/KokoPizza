using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Entities;
using KokoPizza.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace KokoPizza.Persistance.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(KokoPizzaDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Product>> GetProductsByCategoryId(long categoryId)
        => await _dbContext.Products.Where(e => e.CategoryId.Equals(categoryId)).AsNoTracking().ToListAsync();

    public async Task<IReadOnlyList<Product>> GetPagedProductsByCategoryId(long categoryId, int page, int size)
        => await _dbContext.Products
            .Where(e => e.CategoryId.Equals(categoryId))
            .Skip((page - 1) * size)
            .Take(size)
            .AsNoTracking()
            .ToListAsync();

    public async Task<IReadOnlyList<Product>> GetPagedProducts(int page, int size)
        => await _dbContext.Products
            .Skip((page - 1) * size)
            .Take(size)
            .AsNoTracking()
            .ToListAsync();

    public async Task<int> GetCountOfProductsByCategoryId(long categoryId)
        => await _dbContext.Products.Where(e => e.CategoryId.Equals(categoryId)).CountAsync();


    public async Task<int> GetTotalCountOfProducts()
        => await _dbContext.Products.CountAsync();
}