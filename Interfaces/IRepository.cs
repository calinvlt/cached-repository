using System.Threading.Tasks;
using CachedRepository.Data.Entities;

namespace CachedRepository.Data;

public interface IRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity);
    
    Task UpdateAsync(T entity);

    Task DeleteAsync(int entityId);
}