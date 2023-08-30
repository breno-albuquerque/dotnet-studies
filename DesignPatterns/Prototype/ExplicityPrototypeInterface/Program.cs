//  Demo
var p1 = new Person
{
    Age = 23,
    BirthDate = new DateTime(2000, 7, 25),
    Name = "Breno",
    IdInfo = new IdInfo(100)
};

// shallow copy
var p2 = p1.ShallowCopy();

Console.WriteLine("Shallow Copy");
Console.WriteLine("P1 antes: " + p1);
Console.WriteLine("P2 antes: " + p2);

p2.Age = 1;
p2.BirthDate = DateTime.Now;
p2.Name = "Changed";
p2.IdInfo.IdNumber = 1;

Console.WriteLine("P1 depois: " + p1);
Console.WriteLine("P2 depois: " + p2);

// deep copy
var p3 = new Person
{
    Age = 23,
    BirthDate = new DateTime(2000, 7, 25),
    Name = "Breno",
    IdInfo = new IdInfo(100)
};

var p4 = p3.DeepCopy();

Console.WriteLine("Deep Copy");
Console.WriteLine("p3 antes: " + p3);
Console.WriteLine("p4 antes: " + p4);

p3.Age = 1;
p3.BirthDate = DateTime.Now;
p3.Name = "Changed";
p3.IdInfo.IdNumber = 1;

Console.WriteLine("p3 depois: " + p3);
Console.WriteLine("p4 depois: " + p4);


public interface IProtoype<T>
{
    T ShallowCopy();
    T DeepCopy();
}

// Classe a ser clonada
public class Person : IProtoype<Person>
{
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public string Name { get; set; }
    public IdInfo IdInfo { get; set; }

    public Person ShallowCopy()
    {
        return (Person) MemberwiseClone();
    }

    public Person DeepCopy()
    {
        var clone = (Person)MemberwiseClone();

        clone.Age = Age;
        clone.BirthDate = BirthDate;
        clone.Name = Name;
        clone.IdInfo = new IdInfo(IdInfo.IdNumber);

        return clone;
    }

    public override string ToString()
    {
        return $"{nameof(Age)}: {Age}, {nameof(BirthDate)}: {BirthDate}, {nameof(Name)}: {Name}, {nameof(IdInfo)}: {IdInfo}";
    }
}

// Subclasse a ser clonada
public class IdInfo: IProtoype<IdInfo>
{
    public int IdNumber { get; set; }

    public IdInfo(int idNumber)
    {
        IdNumber = idNumber;
    }

    public IdInfo ShallowCopy()
    {
        return (IdInfo)MemberwiseClone();
    }

    public IdInfo DeepCopy()
    {
        return ShallowCopy();
    }

    public override string ToString()
    {
        return $"{nameof(IdNumber)}: {IdNumber}";
    }
}