namespace Demo.SportLeagueManager.Web.Endpoints;

static class WeatherForecastEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/weatherforecast", (HttpContext httpContext) =>
        {
            var forecast = Enumerable.Range(1, 5)
                .Select(index =>
                    new WeatherForecastRecord
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        GetSummaries[Random.Shared.Next(GetSummaries.Length)]
                    ))
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi();
    }

    static string[] GetSummaries => new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy",
        "Hot", "Sweltering", "Scorching"
    };

    record WeatherForecastRecord(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
