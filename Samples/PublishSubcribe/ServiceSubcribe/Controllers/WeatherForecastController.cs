using Dapr;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ServiceSubcribe.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult> Get()
    {
        _logger.LogInformation($"get daprData{_daprData.Name}");
        return Ok(_daprData?.Name);
    }

    DaprData _daprData;

    [Topic("pubsub", "daprData")]
    [HttpPost("/daprDatas")]
    public async Task<ActionResult> CreateData(DaprData daprData)
    {
        _daprData=daprData;
        _logger.LogInformation($"post daprData{_daprData.Name}");
        return Ok(_daprData.Name);
    }


    public class DaprData
    {
        public string Name { set; get; }
    }
}
