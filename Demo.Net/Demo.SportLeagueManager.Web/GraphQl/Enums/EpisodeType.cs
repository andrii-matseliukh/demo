using GraphQL;
using GraphQL.Types;
using System.ComponentModel;

namespace Demo.SportLeagueManager.Web.GraphQl.Enums;

public enum EpisodeType
{
    [Description("Episode 1: The Phantom Menace")]
    [Obsolete("Optional. Sets the GraphQL DeprecationReason for this member.")]
    PHANTOMMENACE = 1,
    NewHope = 4,
    Empire = 5,
    Jedi = 6
}

public class EpisodeEnum : EnumerationGraphType<EpisodeType>
{
    protected override string ChangeEnumCase(string val) => val.ToCamelCase();
}

public class CamelCaseEnumerationGraphType<T> : EnumerationGraphType<T> where T : Enum
{
    protected override string ChangeEnumCase(string val) => val.ToCamelCase();
}
