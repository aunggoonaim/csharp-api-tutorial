using csharp_api_tutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_api_tutorial.Controllers;

[ApiController]
[Route("Hello")]
public class HelloController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "John", "Arachne", "Chilly", "Boy", "Jo"
    };

    private readonly ILogger<HelloController> _logger;
    private readonly TutorialContext _context;

    public HelloController(ILogger<HelloController> logger, TutorialContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpGet]
    [Route("by")]
    public IActionResult GetByContain([FromQuery] string? search)
    {
        var list = new List<int>() { 1, 2, 3, 4, 5 };
        return Ok(
            list.Select(index => new WeatherForecast
            {
                Fullname = Summaries[index - 1],
                Sequence = index,
                IsDeleted = index % 2 == 0
            })
            .ToArray()
        );
    }
}
