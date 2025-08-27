using Demo.SportLeagueManager.Web.GraphQl.Nodes;
using GraphQL.Types;

namespace Demo.SportLeagueManager.Web.GraphQl;

public class AppQuery : ObjectGraphType
{
    public AppQuery()
    {
        Name = "Query";

        // Nodes
        Field<StarWarsNode>("StarWars").Resolve(context => new());
    }
}


