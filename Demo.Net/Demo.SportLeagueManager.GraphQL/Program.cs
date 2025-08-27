using Demo.SportLeagueManager.Web.Configurations;
using Demo.SportLeagueManager.Web.Endpoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthorization();
builder.Services.AddOpenApi();

GraphQlConfigurations.Configure(builder.Services);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

ConfigureEndpoints.Map(app);

app.UseGraphQL();
app.UseGraphQLGraphiQL("/api/ui");

app.Run();

