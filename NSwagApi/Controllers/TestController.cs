using Microsoft.AspNetCore.Mvc;
using Sample;

namespace NSwagApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ISampleApiClient _sampleApiClient;

    public TestController(ISampleApiClient sampleApiClient)
    {
        _sampleApiClient = sampleApiClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetWeatherFromSampleApi()
    {
        var collection = await _sampleApiClient.GetWeatherForecastAsync();

        foreach (var weatherForecast in collection)
        {
            weatherForecast.AdditionalField = "Additional value";
        }

        return Ok(collection);
    }
}