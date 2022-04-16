using Microsoft.AspNetCore.Mvc;
using Dapr.Client;

namespace ServicePublish.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly DaprClient _daprClient;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<string> Get()
    {
        DaprData daprData = new DaprData() { Name = "*****#######********" };
        //pubsub提供消息代理实现的 Dapr 组件名称
        //daprData提供要向其发送消息的主题的名称。
        await _daprClient.PublishEventAsync<DaprData>("pubsub", "daprData", daprData);
        return $"{daprData.Name}已发布";
    }
}

public class DaprData
{
    public string Name { set; get; }
}
