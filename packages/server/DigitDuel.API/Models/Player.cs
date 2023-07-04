namespace DigitDuel.API.Models;

public class Player
{
  public Guid Id { get; set; }
  public DateTime DateCreated { get; set; }
  public DateTime? DateModified { get; set; }

  public required string Name { get; set; }
}