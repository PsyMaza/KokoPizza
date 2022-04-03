using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Entities;
using KokoPizza.Persistance.Context;

namespace KokoPizza.Persistance.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(KokoPizzaDbContext dbContext) : base(dbContext)
    {
    }
}