using System.Text.Json;

// Demo
var person = new Person { Name = "John", Address = new Address { Street = "Street", Number = 1 } };
var copy = person.DeepCopy();

Console.WriteLine("--- Before ---");
Console.WriteLine("Person: " + person);
Console.WriteLine("Copy: " + copy);

copy.Name = "Rick";
copy.Address.Street = "New Street";
copy.Address.Number += 1;

Console.WriteLine("--- After ---");
Console.WriteLine("Person: " + person);
Console.WriteLine("Copy: " + copy);

public static class GenericExtensionMethods
{
    public static T DeepCopy<T>(this T self)
    {
        var serialized = JsonSerializer.Serialize(self);
        return JsonSerializer.Deserialize<T>(serialized);
    }
}

// Classe a ser copiada
public class Person
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
    }
}

// Classe membro de Person 
public class Address
{
    public string Street { get; set; }
    public int Number { get; set; }

    public override string ToString()
    {
        return $"{nameof(Street)}: {Street}, {nameof(Number)}: {Number}";
    }
}
