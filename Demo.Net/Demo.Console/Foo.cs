using System.ComponentModel.DataAnnotations;

public class Foo(string name, int age, double price)
{
    public string Name { get; } = name;
    public int Age { get; } = age;
    public double Price { get; } = price;

    public void Print() => Display();
    public void Display()
    {
        var print = (string version = "1.0") => Console.WriteLine(
            $"Version: {version}, Name: {Name}, Age: {Age}, Price: {Price}");
        print();
        print("2.1");
    }
}