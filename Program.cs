using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using CachedRepository.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddDbContext<PersonContext>();
builder.Services.AddScoped<IReadOnlyRepository<Person>, CachedPersonRepository>();
builder.Services.AddScoped(typeof(GenericRepository<>));
builder.Services.AddScoped<PersonRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
