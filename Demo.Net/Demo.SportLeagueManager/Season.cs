using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.SportLeagueManager;

public record Season
{
    public string Title { get; }
    public SeasonPeriod SeasonPeriod { get; }

    public TeamCollection TeamCollection { get; } = new TeamCollection(Enumerable.Empty<ITeam>());

    public Season(string title, SeasonPeriod period)
    {
        Title = title;
        SeasonPeriod = period;
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
            throw new ArgumentException("Invalid season period");
        }

        StartIn = startIn;
        EndIn = endIn;
    }
}
