using Demo.SportLeagueManager.Web.GraphQl.Enums;
using Demo.SportLeagueManager.Web.GraphQl.Models;
using GraphQL.Types;

namespace Demo.SportLeagueManager.Web.GraphQl.Nodes;

public class StarWarsNode : ObjectGraphType
{
    public StarWarsNode()
    {
        Name = "StarWarsNode";

        Field<DroidType>("droid").Resolve(context => new Droid
        {
            Name = "1",
            AppearsIn = new List<EpisodeType> {
                EpisodeType.Jedi,
                EpisodeType.Empire
            }
        });
    }
}
