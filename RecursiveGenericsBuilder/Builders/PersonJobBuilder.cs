namespace RecursiveGenericsBuilder.Builders;

public class PersonJobBuilder<T> : PersonInfoBuilder<PersonJobBuilder<T>>
    where T : PersonJobBuilder<T>
{
    public T WorkAs(string position)
    {
        person.Position = position;
        return (T) this;
    }
}