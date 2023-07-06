using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FluentValidation;

namespace DigitDuel.API.Features.Game;

public class GameDto
{
  public Guid Id { get; set; }
  public DateTime DateCreated { get; set; }
  public DateTime? DateModified { get; set; }

  public string Name { get; set; } = null!;
  public Difficulty Difficulty { get; set; }

  public int? MaxPlayers { get; set; }

  public string Puzzle { get; set; } = null!;
  public string OriginalPuzzle { get; set; } = null!;

  public IEnumerable<MoveDto> Moves { get; set; } = null!;
  public IEnumerable<PlayerDto> Players { get; set; } = null!;
}

public class MoveDto
{
  public Guid Id { get; set; }
  public DateTime DateCreated { get; set; }
  public DateTime? DateModified { get; set; }

  public Guid GameId { get; set; }
  public Guid PlayerId { get; set; }

  public int Index { get; set; }
  public int Row { get; set; }
  public int Column { get; set; }

  public string Value { get; set; } = null!;
}

public class PlayerDto
{
  public Guid Id { get; set; }
  public DateTime DateCreated { get; set; }
  public DateTime? DateModified { get; set; }

  public required string Name { get; set; }
}

public class CreateGameDto
{
  public string? Name { get; set; }

  public int? MaxPlayers { get; set; }

  public string? Password { get; set; }

  [JsonConverter(typeof(JsonStringEnumConverter))]
  public Difficulty? Difficulty { get; set; }
}

public class CreateGameDtoValidator : AbstractValidator<CreateGameDto>
{
  public CreateGameDtoValidator()
  {
    RuleFor(x => x.Name)
      .Length(1, 16);

    RuleFor(x => x.MaxPlayers)
      .GreaterThanOrEqualTo(1)
      .LessThanOrEqualTo(8);

    RuleFor(x => x.Password)
      .Length(1, 16);

    RuleFor(x => x.Difficulty)
      .IsInEnum();
  }
}