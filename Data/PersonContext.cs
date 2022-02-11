using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace CachedRepository.Data;

public class PersonContext : DbContext
{
  public DbSet<Person> People { get; set; }

  public string DbPath { get; }

  public PersonContext()
  {
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    DbPath = Path.Join(path, "people.db");
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
}
