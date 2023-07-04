namespace DigitDuel.API.Models;

public class Game
{
  public Guid  Id { get; set; }
  public DateTime DateCreated { get; set; }
  public DateTime? DateModified { get; set; }

  public required string Name { get; set; } // the unique name used to join a game by URL
  public required Difficulty Difficulty { get; set; } // the difficuty of the game

  public int? MaxPlayers { get; set; } // the max number of players allowed in the game
  public string? Password { get; set; } // the password needed to join a game

  public required string Puzzle { get; set; } // the string representation of the puzzle as its edited
  public required string Solution { get; set; } // the string representation of the solution to the puzzle
  public required string OriginalPuzzle { get; set; } // the string representation of the puzzle as it was generated

  public ICollection<Move>? Moves { get; set;} // the moves made in the game
}

public enum Difficulty
{
  Easy,
  Medium,
  Hard,
  Expert
}