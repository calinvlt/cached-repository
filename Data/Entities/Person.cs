using CachedRepository.Data.Entities;

namespace CachedRepository.Data
{
    public class Person : BaseEntity
    {
        public string? FullName { get; set; }
    }
}