using Microsoft.EntityFrameworkCore;
using DigitDuel.API.Models;

namespace DigitDuel.API.Data;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options)
  { }

  public DbSet<Test> Tests => Set<Test>();
}