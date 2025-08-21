using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Demo.SportLeagueManager.GraphQL;

public enum EpisodeType
{
    [Description("Episode 1: The Phantom Menace")]
    [Obsolete("Optional. Sets the GraphQL DeprecationReason for this member.")]
    PHANTOMMENACE = 1,
    NewHope = 4,
    Empire = 5,
    Jedi = 6
}
//EnumerationGraphType<T> where T : Enum
public class EpisodeEnum : EnumerationGraphType<EpisodeType>
{
    protected override string ChangeEnumCase(string val) => val.ToCamelCase();
}

public class CamelCaseEnumerationGraphType<T> : EnumerationGraphType<T> where T : Enum
{
    protected override string ChangeEnumCase(string val) => val.ToCamelCase();
}

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

public class AppQuery : ObjectGraphType
{
    public AppQuery()
    {
        Name = "Query";

        Field<StarWarsQuery>("StarWars").Resolve(context => new());
    }
}

public class AppSchema : Schema
{
    public AppSchema(IServiceProvider services) : base(services)
    {
        Query = services.GetService<AppQuery>()!;
    }
}

public class StarWarsQuery : ObjectGraphType
{
    public StarWarsQuery()
    {
        Name = "StarWarsNode";

        Field<DroidType>("droid").Resolve(context => new Droid
        {
            Name = "1",
            AppearsIn = new List<EpisodeType> { EpisodeType.Jedi, EpisodeType.Empire }
        });
    }
}
