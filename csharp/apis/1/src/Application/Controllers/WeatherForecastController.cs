using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[ApiVersion("1", Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[] {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger) {
        _logger = logger;
    }

    /// <summary>
    /// Hello, I just return the most unique phrase in programming ever 
    /// </summary>
    /// <returns>string</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public string Get()
    {
      return "hello world";
    }

    [HttpGet(Name = "OtherThanGet")]
    public string Get2(){
      return "something else";
    }
}
