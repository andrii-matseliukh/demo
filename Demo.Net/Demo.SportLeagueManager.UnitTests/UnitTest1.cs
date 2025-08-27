using Demo.SportLeagueManager.Domain;
using Microsoft.Extensions.Time.Testing;
using Shouldly;

namespace Demo.SportLeagueManager.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        
    }

    [Fact]
    public void CreateSeason_SeasonCreated()
    {
        var timeProvider = new FakeTimeProvider();
        var seasonName = "Default Season 1";
        DateOnly startOfSeason = DateOnly.FromDateTime(timeProvider.GetUtcNow().Date);
        DateOnly endOfSeason = startOfSeason.AddMonths(2);
        var season = Season.CreateSeason(seasonName, startOfSeason, endOfSeason);

        season.ShouldNotBeNull();
        season.Title.ShouldBe(seasonName);
    }

    [Fact]
    public void CreateSeason_WithInvalidPeriod_ThrowsException()
    {
        var timeProvider = new FakeTimeProvider();

        var admin = Admin.CreateAdmin();

        DateOnly startOfSeason = DateOnly.FromDateTime(timeProvider.GetUtcNow().Date);
        DateOnly endOfSeason = startOfSeason.AddMonths(-1);

        Should.Throw<ArgumentException>(() =>
        {
            Season.CreateSeason("default name", startOfSeason, endOfSeason);
        });
    }

    [Fact]
    public void AddTeamToSeason_TeamAdded()
    {
        var timeProvider = new FakeTimeProvider();

        var season = Season.CreateSeason(
            "Default Season 1", 
            DateOnly.FromDateTime(timeProvider.GetUtcNow().Date), 
            DateOnly.FromDateTime(timeProvider.GetUtcNow().Date).AddMonths(2));

        var team = new EmptyTeam("Циркачі");
        season.TeamCollection.Add(team);

        season.TeamCollection.GetAll().ShouldContain(team);
    }

    [Fact]
    public void AddNullTeamToSeason_AddsNothing()
    {
        var timeProvider = new FakeTimeProvider();

        var season = Season.CreateSeason(
            "Default Season 1",
            DateOnly.FromDateTime(timeProvider.GetUtcNow().Date),
            DateOnly.FromDateTime(timeProvider.GetUtcNow().Date).AddMonths(2));

        ITeam nullTeam = null;
        season.TeamCollection.Add(nullTeam);

        season.TeamCollection.GetAll().ShouldBeEmpty();
    }

    [Fact]
    public void DifferentWaysToGetTeam()
    {
        var timeProvider = new FakeTimeProvider();

        var seasonName = "Default Season 1";
        var startIn = DateOnly.FromDateTime(timeProvider.GetUtcNow().Date);
        var endIn = DateOnly.FromDateTime(timeProvider.GetUtcNow().Date).AddMonths(2);
        var season = Season.CreateSeason(seasonName, startIn, endIn);

        season.TeamCollection.Add(new EmptyTeam("Циркачі"));
        season.TeamCollection.Add(new EmptyTeam("Navi junior"));
        season.TeamCollection.Add(new EmptyTeam("Navi"));
        season.TeamCollection.Add(new EmptyTeam("Shevchenko"));
        season.TeamCollection.Add(new EmptyTeam("Dynamo Kyiv"));
        season.TeamCollection.Add(new EmptyTeam("Shakhtar Donetsk"));
        season.TeamCollection.Add(new EmptyTeam("Metalist Kharkiv"));
        season.TeamCollection.Add(new EmptyTeam("Vorskla Poltava"));
        season.TeamCollection.Add(new EmptyTeam("Zorya Luhansk"));

        var cases = new List<ITeam>
        {
            season.TeamCollection[new Index(0)],
            season.TeamCollection[0],
            season.TeamCollection[^1],
            season.TeamCollection[^2],
        };
        cases.AddRange(season.TeamCollection[0..2]);
        cases.AddRange(season.TeamCollection[1..3]);
        cases.AddRange(season.TeamCollection[..2]);
        cases.AddRange(season.TeamCollection[2..]);

        foreach (var @case in cases) @case.ShouldNotBeNull();
    }
}

