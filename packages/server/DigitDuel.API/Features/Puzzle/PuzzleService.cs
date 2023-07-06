using System.Text.Json;
using DigitDuel.API.Features.Game;

namespace DigitDuel.API.Features.Puzzle;

public interface IPuzzleService
{
  Task<Puzzle> GetPuzzle(Difficulty difficulty);
}

public class PuzzleService : IPuzzleService
{
  private static readonly HttpClient _client;

  static PuzzleService()
  {
    _client = new HttpClient
    {
      BaseAddress = new Uri("http://localhost:7071") // TODO: get from env
    };
  }

  public async Task<Puzzle> GetPuzzle(Difficulty difficulty)
  {
    var url = string.Format("/api/getSudokuPuzzle?difficulty={0}", "Hard");
    var response = await _client.GetAsync(url);

    if (!response.IsSuccessStatusCode)
      throw new HttpRequestException(response.ReasonPhrase);

    var stringResponse = await response.Content.ReadAsStringAsync();
    if (stringResponse == null)
      throw new Exception(); // FIXME:

    var result = JsonSerializer.Deserialize<GetPuzzleResponse>(stringResponse,
      new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

    if (result == null)
      throw new Exception(); ; // FIXME:

    return new Puzzle
    {
      CurrentPuzzle = result.Result.Puzzle,
      OriginalPuzzle = result.Result.Puzzle,
      Solution = result.Result.Solution
    };
  }

  class GetPuzzleResponse
  {
    public GetPuzzleResult Result { get; set; } = null!;
  }

  class GetPuzzleResult
  {
    public string Puzzle { get; set; } = null!;
    public string Solution { get; set; } = null!;
  }
}