using GraphQL.Types;

// fix namespace    
namespace Demo.SportLeagueManager.Web.GraphQl;

public class AppSchema : Schema
{
    public AppSchema(IServiceProvider services) : base(services)
    {
        Query = services.GetService<AppQuery>()!;
    }
}
