namespace DigitDuel.API.Models;

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