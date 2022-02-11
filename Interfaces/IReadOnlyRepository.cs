using System.Collections.Generic;
using System.Threading.Tasks;

using CachedRepository.Data.Entities;

namespace CachedRepository.Data;

public interface IReadOnlyRepository<T> where T: BaseEntity {
    Task<T> GetByIdAsync(int id);
    Task<List<T>> ListAsync();
}