using DigitDuel.API.Data;
using DigitDuel.API.Features.Puzzle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitDuel.API.Features.Game;

[ApiController]
[Route("[controller]")]
public class GameController : Controller
{
  private readonly DataContext _context;
  private readonly IPuzzleService _puzzleService;

  public GameController(DataContext context, IPuzzleService puzzleService)
  {
    _context = context;
    _puzzleService = puzzleService;
  }

  [HttpPost]
  public async Task<IActionResult> CreateGame([FromBody] CreateGameDto createGameDto)
  {
    // validate req
    var validator = new CreateGameDtoValidator();
    var results = validator.Validate(createGameDto);

    if (!results.IsValid) return BadRequest(results.Errors);

    // get the player by cookie, or create a new one if no/bad cookie
    Player? player = null;
    var playerId = Request.Cookies["player_id"];

    if (!(playerId is null))
      player = await _context.Players.FirstOrDefaultAsync(p => p.Id == Guid.Parse(playerId));
    if (player is null)
      player = new Player
      {
        DateCreated = DateTime.Now,
        Name = GenerateName()
      };

    // set defaults if not sent in req
    var name = createGameDto.Name ?? GenerateName();
    var difficulty = createGameDto.Difficulty ?? RandomDifficulty();
    var puzzle = await _puzzleService.GetPuzzle(difficulty);

    // create & save game/player
    var gameEntity = new Game
    {
      DateCreated = DateTime.Now,
      Name = name,
      Difficulty = difficulty,
      MaxPlayers = createGameDto.MaxPlayers,
      Password = createGameDto.Password,
      Puzzle = puzzle.CurrentPuzzle,
      Solution = puzzle.Solution,
      OriginalPuzzle = puzzle.OriginalPuzzle,
      Players = new List<Player> { player }
    };

    _context.Games.Add(gameEntity);
    var result = await _context.SaveChangesAsync();

    // set player cookie
    Response.Cookies.Append("player_id", player.Id.ToString());

    // return dto
    return Ok(new GameDto
    {
      Id = gameEntity.Id,
      DateCreated = gameEntity.DateCreated,
      DateModified = gameEntity.DateModified,
      Name = gameEntity.Name,
      Difficulty = gameEntity.Difficulty, // TODO: convert to string value
      MaxPlayers = gameEntity.MaxPlayers,
      Puzzle = gameEntity.Puzzle,
      OriginalPuzzle = gameEntity.OriginalPuzzle
    });
  }

  private string GenerateName()
  {
    return Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
  }

  private Difficulty RandomDifficulty()
  {
    var values = Enum.GetValues(typeof(Difficulty));
    var random = new Random();

    return (Difficulty)values.GetValue(random.Next(values.Length));
  }
}