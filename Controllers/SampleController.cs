using Microsoft.AspNetCore.Mvc;

namespace csharp_api_tutorial.Controllers;

[ApiController]
[Route("Sample")]
public class SampleController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "John", "Arachne", "Chilly", "Boy", "Jo"
    };

    private readonly ILogger<SampleController> _logger;

    public SampleController(ILogger<SampleController> logger)
    {
        _logger = logger;
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
