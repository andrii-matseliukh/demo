namespace Demo.CSharpLanguage;

class Class1B
{
    public int MyProperty { get; set; }
    public void MainB()
    {
        DateTime now = DateTime.Now;
        Console.WriteLine($"Local: {TimeProvider.System.GetLocalNow()}");
        Console.WriteLine($"Utc:   {TimeProvider.System.GetUtcNow()}");

        var person1 = new Person("John Doe", 30);
        var person2 = person1;
        //person2.age = 31;
        Console.WriteLine();
    }


}

record Person(string name, int age);
