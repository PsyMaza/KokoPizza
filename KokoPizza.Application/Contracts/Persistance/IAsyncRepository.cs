using KokoPizza.Core.Domain.Common;
using KokoPizza.Core.Domain.Entities;

namespace KokoPizza.Core.Application.Contracts.Persistance;

public interface IAsyncRepository<T> where T : class, IEntity
{
    Task<T?> GetByIdAsync(long id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    IUnitOfWork UnitOfWork { get; }
}