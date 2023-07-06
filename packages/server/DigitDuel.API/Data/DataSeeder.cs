using Microsoft.EntityFrameworkCore;

namespace DigitDuel.API.Data;

public static class DataSeeder
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var context = new DataContext(
      serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()
    ))
    {
      // if (context.Tests.Any())
      // {
      //   return;
      // }

      // context.Tests.Add(new Test {
      //   DateCreated = DateTime.Now,
      //   Value = "gggggg bbb"
      // });
      // context.SaveChanges();
    }
  }
}