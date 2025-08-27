namespace Demo.SportLeagueManager.Domain;

public abstract record ITeam;

public record EmptyTeam(string name) : ITeam;

public record Team(string name, IEnumerable<Player> players) : ITeam
{
    public string Name { get; } = name;
    public List<Player> Players { get; } = players.ToList();
}

