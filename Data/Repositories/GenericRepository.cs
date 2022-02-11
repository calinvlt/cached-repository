using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CachedRepository.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace CachedRepository.Data;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly PersonContext _dbContext;

    public GenericRepository(PersonContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);

    public async virtual Task<List<T>> ListAsync() => await _dbContext.Set<T>().ToListAsync();

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(int entityId)
    {
        var entity = await GetByIdAsync(entityId);
        if (entity != null)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}