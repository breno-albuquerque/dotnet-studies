var person = new Person
{
    Name = "Person",
    Age = 20
};

var person2 = new Person();

Console.WriteLine("Person: " + person);
Console.WriteLine("Person 2: " + person2);

public class Person
{
    //  Static fields 
    private static string _name;
    private static int _age;

    // Non static properties
    public string Name
    {
        get => _name;
        set => _name = value;
    }
    
    public int Age
    {
        get => _age;
        set => _age = value;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
    }
}