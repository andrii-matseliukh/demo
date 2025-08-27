using Demo.SportLeagueManager.Web.GraphQl.Enums;
using GraphQL.Types;

namespace Demo.SportLeagueManager.Web.GraphQl.Models;

public class Droid
{
    public string Name { get; set; }
    public List<EpisodeType> AppearsIn { get; set; }
}

public class DroidType : ObjectGraphType<Droid>
{
    public DroidType()
    {
        Name = "Droid";
        Description = "A mechanical creature in the Star Wars universe.";
        Field(d => d.Name, nullable: true).Description("The name of the droid.");
        Field<ListGraphType<EpisodeEnum>>(nameof(Droid.AppearsIn)).Description("Which movie they appear in.");
        //Field(d => d.AppearsIn, nullable: true).Description("Which movies the droid appears in.");
    }
}
