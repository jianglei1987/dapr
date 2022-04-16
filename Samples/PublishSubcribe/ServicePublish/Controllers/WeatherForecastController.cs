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
        //pubsub�ṩ��Ϣ����ʵ�ֵ� Dapr �������
        //daprData�ṩҪ���䷢����Ϣ����������ơ�
        await _daprClient.PublishEventAsync<DaprData>("pubsub", "daprData", daprData);
        return $"{daprData.Name}�ѷ���";
    }
}

public class DaprData
{
    public string Name { set; get; }
}
