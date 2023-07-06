using DigitDuel.API.Features.Game;
using Microsoft.EntityFrameworkCore;

namespace DigitDuel.API.Data;

public class DataContext : DbContext
{
  public DbSet<Game> Games => Set<Game>();
  public DbSet<Player> Players => Set<Player>();

  public DataContext(DbContextOptions<DataContext> options) : base(options)
  { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    GameModelSetup.OnModelCreating(modelBuilder);
  }
}