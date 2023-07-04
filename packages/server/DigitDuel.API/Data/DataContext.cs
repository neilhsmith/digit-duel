using Microsoft.EntityFrameworkCore;
using DigitDuel.API.Models;

namespace DigitDuel.API.Data;

public class DataContext : DbContext
{
  public DbSet<Game> Games => Set<Game>();

  public DataContext(DbContextOptions<DataContext> options) : base(options)
  { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder
      .Entity<Game>()
      .Property(e => e.Difficulty)
      .HasConversion(
        v => v.ToString(),
        v => (Difficulty)Enum.Parse(typeof(Difficulty), v));
  }
}