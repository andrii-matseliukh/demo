namespace Demo.SportLeagueManager.Domain;

public record Season
{
    public string Title { get; }
    public SeasonPeriod SeasonPeriod { get; }

    public TeamCollection TeamCollection { get; } = new TeamCollection(Enumerable.Empty<ITeam>());

    private Season(string title, SeasonPeriod period)
    {
        Title = title;
        SeasonPeriod = period;
    }

    public static Season CreateSeason(string title, DateOnly startIn, DateOnly endIn)
    {
        return new Season(title, new SeasonPeriod(startIn, endIn));
    }
}

public record SeasonPeriod
{
    public DateOnly StartIn { get; }
    public DateOnly EndIn { get; }

    public SeasonPeriod(DateOnly startIn, DateOnly endIn)
    {
        if (startIn >= endIn)
        {
            throw new ArgumentException($"Invalid season period: {startIn} - {endIn}");
        }

        StartIn = startIn;
        EndIn = endIn;
    }
}
