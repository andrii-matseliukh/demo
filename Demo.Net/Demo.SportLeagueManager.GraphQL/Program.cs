using Demo.SportLeagueManager.GraphQL;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.Identity.Web.Resource;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddGraphQL(c => c
        .AddSystemTextJson()
        .AddSchema<AppSchema>()
        .AddGraphTypes(Assembly.GetAssembly(typeof(AppSchema)) ?? Assembly.GetExecutingAssembly())
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy",
    "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (HttpContext httpContext) =>
{
    var forecast = Enumerable.Range(1, 5)
        .Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.UseGraphQL();
app.UseGraphQLGraphiQL("/api/ui");

app.Run();


//static void ConfigureServices(IServiceCollection services)
//{
//    services.AddSingleton<EpisodeEnum>();
//    services.AddSingleton<EpisodeEnum>();
//    services.AddSingleton<AppQuery>();
//    services.AddSingleton<StarWarsQuery>();
//    services.AddSingleton<ISchema, AppSchema>();
//}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

