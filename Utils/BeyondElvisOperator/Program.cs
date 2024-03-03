// Demo
var person = new Person();

var postcode = person.With(x => x.Address).With(x => x.PostCode);

var postcode2 = person
    .If(HasMedicalRecord)
    .With(x => x.Address)
    .Do(CheckAddress)
    .Return(x => x.PostCode, "UNKNOWN");

Console.WriteLine(postcode, postcode2);

// Forma de fazer verificações de nulo indo além de simplesmente utilizar o elvis operator
void CheckAddress(Address pAddress)
{
    // logic
}

bool HasMedicalRecord(Person person)
{
    // logic
    return true;
}

public static class Maybe
{
    public static TResult? With<TInput, TResult>(this TInput? o, Func<TInput, TResult> evaluator)
        where TResult : class
        where TInput : class
    {
        if (o is null) return null;
        
        return evaluator(o);
    }

    public static TInput? If<TInput>(this TInput? o, Func<TInput, bool> evaluator)
        where TInput : class
    {
        if (o is null) return null;
        
        return evaluator(o) ? o : null;
    }

    public static TInput? Do<TInput>(this TInput? o, Action<TInput> action)
        where TInput : class
    {
        if (o is null) return null;
        
        action(o);
        
        return o;
    }

    public static TResult Return<TInput, TResult>(this TInput? o, Func<TInput, TResult> evaluator, TResult failureValue)
        where TInput : class
    {
        if (o is null) return failureValue;
        
        return evaluator(o);
    }

    public static TResult WithValue<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator)
        where TInput : struct
    {
        return evaluator(o);
    }
}

public class Person
{
    public Address Address { get; set; }
}

public class Address
{
    public string PostCode { get; set; }
}
