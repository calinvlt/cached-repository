using Microsoft.Extensions.Caching.Memory;

namespace CachedRepository.Data;

public class CachedPersonRepository : IReadOnlyRepository<Person>
{
    private readonly PersonRepository _repository;
    private readonly IMemoryCache _cache;
    private readonly MemoryCacheEntryOptions _options;

    private const string MyCacheKey = "Person";

    public CachedPersonRepository(PersonRepository repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
        _options = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(5));;
    }

    public async Task<Person> GetByIdAsync(int id)
    {
        var key = $"{MyCacheKey}-{id}";
        return await _cache.GetOrCreateAsync(key, async e =>
        {
            e.SetOptions(_options);
            return await _repository.GetByIdAsync(id);
        });
    }

    public async Task<List<Person>> ListAsync() =>
      await _cache.GetOrCreate(MyCacheKey, async e =>
      {
          e.SetOptions(_options);
          return await _repository.ListAsync();
      });
}