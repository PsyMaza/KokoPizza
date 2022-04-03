using KokoPizza.Core.Domain.Entities;

namespace KokoPizza.Core.Application.Contracts.Persistance;

public interface ICategoryRepository : IAsyncRepository<Category>
{
    
}