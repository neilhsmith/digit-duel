using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DigitDuel.API.Features.Game;

public class Game
{
  public Guid Id { get; set; }
  public DateTime DateCreated { get; set; }
  public DateTime? DateModified { get; set; }

  public string Name { get; set; } = null!; // the unique name used to join a game by URL
  public Difficulty Difficulty { get; set; } // the difficuty of the game

  public int? MaxPlayers { get; set; } // the max number of players allowed in the game
  public string? Password { get; set; } // the password needed to join a game

  public string Puzzle { get; set; } = null!; // the string representation of the puzzle as its edited
  public string Solution { get; set; } = null!; // the string representation of the solution to the puzzle
  public string OriginalPuzzle { get; set; } = null!; // the string representation of the puzzle as it was generated

  public ICollection<Move>? Moves { get; set; } // the moves made in the game
  public ICollection<Player>? Players { get; set; } // the players that have joined the game
}

public class Move
{
  public Guid Id { get; set; }
  public DateTime DateCreated { get; set; }
  public DateTime? DateModified { get; set; }

  public Guid GameId { get; set; }
  public required Game Game { get; set; }
  public Guid PlayerId { get; set; }
  public required Player Player { get; set; }

  public int Index { get; set; } // the 0 based index of the cell within the puzzle this move was made in
  public int Row { get; set; } // the 0 based row of the cell within the puzzle this move was made in
  public int Column { get; set; } // the 0 based column of the cell within the puzzle this move was made in

  public required string Value { get; set; } // the value given to the cell
}

public class Player
{
  public Guid Id { get; set; }
  public DateTime DateCreated { get; set; }
  public DateTime? DateModified { get; set; }

  public required string Name { get; set; }

  public ICollection<Game>? Games { get; set; } // the games this player has played in
}

public enum Difficulty
{
  Easy,
  Medium,
  Hard,
  Expert
}

// ---

public static class GameModelSetup
{
  public static void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder
      .Entity<Game>()
      .Property(e => e.Difficulty)
      .HasConversion(
        v => v.ToString(),
        v => (Difficulty)Enum.Parse(typeof(Difficulty), v));
  }
}

// public class GameMapping : Profile
// {
//   public GameMapping()
//   {
//     CreateMap<GameDto, Game>()
//       .ForMember(dest => dest.Id, opt => opt.AllowNull())
//       .ForMember(dest => dest.DateCreated, opt => opt.AllowNull())
//       .ForMember(dest => dest.Puzzle, opt => opt.AllowNull())
//       .ForMember(dest => dest.Solution, opt => opt.AllowNull())
//       .ForMember(dest => dest.OriginalPuzzle, opt => opt.AllowNull());
//   }
// }