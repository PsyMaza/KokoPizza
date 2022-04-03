using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Common;
using KokoPizza.Core.Domain.Entities;
using KokoPizza.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace KokoPizza.Persistance.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class, IEntity
{
    protected readonly KokoPizzaDbContext _dbContext;

    public IUnitOfWork UnitOfWork
    {
        get
        {
            return _dbContext;
        }
    }

    public BaseRepository(KokoPizzaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T?> GetByIdAsync(long id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
    {
        return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        if (entity is IDeletable item)
        {
            item.IsDeleted = true;
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        else
            _dbContext.Set<T>().Remove(entity);

        await _dbContext.SaveChangesAsync();
    }
}