using Demo.SportLeagueManager.Web.GraphQl;
using GraphQL;
using System.Reflection;

namespace Demo.SportLeagueManager.Web.Configurations;

public static class GraphQlConfigurations
{
    public static void Configure(IServiceCollection services)
    {
        services
        .AddGraphQL(c => c
            .AddSystemTextJson()
            .AddSchema<AppSchema>()
            .AddGraphTypes(Assembly.GetAssembly(typeof(AppSchema)) ?? Assembly.GetExecutingAssembly())
        );
    }
}
