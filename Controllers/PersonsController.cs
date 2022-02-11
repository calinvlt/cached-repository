using System.Collections.Generic;

using CachedRepository.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CachedRepository.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonsController : ControllerBase
{
    private readonly ILogger<PersonsController> _logger;
    private readonly IReadOnlyRepository<Person> _readOnlyRepository;

    public PersonsController(ILogger<PersonsController> logger, IReadOnlyRepository<Person> readOnlyRepository)
    {
        _logger = logger;
        _readOnlyRepository = readOnlyRepository;
    }

    [HttpGet(Name = "GetPersons")]
    public async Task<IEnumerable<Person>> Get()
    {
        return await _readOnlyRepository.ListAsync();
    }
}
