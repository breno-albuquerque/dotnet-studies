using RecursiveGenericsBuilder.Builders;

namespace RecursiveGenericsBuilder;

public class Person
{
    public string Name { get; set; }

    public string Position { get; set; }

    public static Builder Create => new Builder();
    
    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
    }
}

public class Builder : PersonJobBuilder<Builder>
{
        
}