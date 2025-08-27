namespace Demo.SportLeagueManager.Web.Endpoints;


static class ConfigureEndpoints
{
    public static void Map(WebApplication app)
    {
        WeatherForecastEndpoints.Map(app);
    }
}
