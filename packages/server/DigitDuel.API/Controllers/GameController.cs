// using System.ComponentModel.DataAnnotations;
// using System.Text.Json.Serialization;
// using DigitDuel.API.Data;
// using DigitDuel.API.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace DigitDuel.API.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class GameController : ControllerBase
// {
//   private readonly DataContext _context;

//   public GameController(DataContext context)
//   {
//     _context = context;
//   }

//   [HttpPost(Name = "CreateGame")]
//   public IActionResult CreateGame([FromBody] CreateGameDto game)
//   {
//     if (game.Name != null && _context.Games.Any(g => g.Name == game.Name))
//     {
//       return BadRequest("Name is not unique");
//     }

//     var newGame = new Game()
//     {
//       Name = game.Name ?? "Todo: name",
//       Difficulty = game.Difficulty ?? Difficulty.Medium,
//       MaxPlayers = game.MaxPlayers,
//       Password = game.Password,
//       Puzzle = "todo",
//       Solution = "todo",
//       OriginalPuzzle = "todo",
//     };

//     // _context.Games.Add(newGame);
//     // _context.SaveChanges();

//     return Ok(new
//     {
//       Id = newGame.Id,
//       Name = newGame.Name,
//       Difficulty = newGame.Difficulty,
//       MaxPlayers = newGame.MaxPlayers
//     });
//   }
// }

// public class CreateGameDto
// {
//   [Range(1, 8)]
//   public int? MaxPlayers { get; set; }

//   [MinLength(1)]
//   [MaxLength(16)]
//   public string? Name { get; set; }

//   [MinLength(1)]
//   [MaxLength(16)]
//   public string? Password { get; set; }

//   [Required]
//   [JsonConverter(typeof(JsonStringEnumConverter))]
//   public Difficulty? Difficulty { get; set; }
// }