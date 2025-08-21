using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

//HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

//using IHost host = builder.Build();

//host.Run();

var p = new Asset("abc");
object y = "5";
int z = (int)y;          // Runtime error, downcast failed

class Person
{
    public int Age { get; set; } = 23;
    public string Name { get; set; }
    public Person()
    {
        
    }
    public Person(string name)
    {
        Name = name;
        Console.WriteLine($"Age: {Age}");
    }
}

class Student: Person
{
    public int Age { get; set; } = 24;
    public Student()
    {
        Console.WriteLine($"Age: {Age}");
    }
}

public class Asset
{
    public required string Name;

    public Asset() { }

    [SetsRequiredMembers]
    public Asset(string n) => Name = n;
}