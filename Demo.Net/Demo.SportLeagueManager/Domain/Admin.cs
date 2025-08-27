namespace Demo.SportLeagueManager.Domain;

public sealed class Admin
{
    public string Name { get; }

    private Admin(string name) => Name = name;

    public static Admin CreateAdmin() => new("default name");
}

