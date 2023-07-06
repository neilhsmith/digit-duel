using Microsoft.AspNetCore.Mvc;

namespace DigitDuel.API.Features.Test;

[ApiController]
[Route("[controller]")]
public class TestController : Controller
{
  [HttpGet]
  public IActionResult Get()
  {
    return Ok("Test");
  }
}