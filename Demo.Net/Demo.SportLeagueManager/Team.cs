using System.Runtime.CompilerServices;

namespace Demo.SportLeagueManager;

public abstract record ITeam;
public record EmptyTeam(string name) : ITeam;
public record Team(string name, IEnumerable<Player> players) : ITeam
{
    public string Name { get; } = name;
    public List<Player> Players { get; } = players.ToList();
}

public record Player(string name);

public class TeamCollection(IEnumerable<ITeam> input)
{
    private readonly List<ITeam> _items = input.ToList();

    public void Add(ITeam team)
    {
        if (team == null) return;
        _items.Add(team);
    }

    public IEnumerable<ITeam> GetAll()
    {
        foreach (var team in _items)
        {
            yield return team;
        }
    }

    public IEnumerable<ITeam> this[Range range] => _items[range];

    public ITeam this[Index index] => _items[index];
}