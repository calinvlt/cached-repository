using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CachedRepository.Data;

public class PersonRepository : GenericRepository<Person>
{
    public PersonRepository(PersonContext dbContext) : base(dbContext)
    {
    }
    
    public override async Task<List<Person>> ListAsync() => await _dbContext.People.ToListAsync();
}
