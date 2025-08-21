namespace Demo.SportLeagueManager;

public sealed class Admin
{
    public string Name { get; }

    private Admin(string name) => (Name) = (name);

    public static Admin CreateAdmin() => new("default name");

    public Season CreateSeason(string title, DateOnly startIn, DateOnly endIn)
    {
        return new Season(title, new SeasonPeriod(startIn, endIn));
    }
}

