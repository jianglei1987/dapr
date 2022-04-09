using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Service_Start.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var daprClient = new DaprClientBuilder().Build();
        return await daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(HttpMethod.Get,"serviceend", "WeatherForecast");
    }
}
