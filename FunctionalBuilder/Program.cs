// Demo
var car = new CarBuilder()
    .Brand("Lamborghini")
    .Model("Urus")
    .Price(3200000f)
    .Build();

Console.WriteLine(car);

// Classe que deve ser construída
public class Car
{
    public string Brand { get; set; }

    public string Model { get; set; }

    public float Price { get; set; }

    public override string ToString()
    {
        return $"{nameof(Brand)}: {Brand}, {nameof(Model)}: {Model}, {nameof(Price)}: {Price}";
    }
} 

// Builder Funcional Genérico
public abstract class GenericFuncionalBuilder<TSubject, TSelf>
    where TSubject : new()
    where TSelf : GenericFuncionalBuilder<TSubject, TSelf>
{
    public List<Func<TSubject, TSubject>> actions = new();

    public TSelf Do(Action<TSubject> action)
    {
        AddAction(action);
        return (TSelf)this;
    }

    private TSelf AddAction(Action<TSubject> action)
    {
        actions.Add(subject => { action(subject);
            return subject;
        });
        return (TSelf)this;
    }

    public TSubject Build()
    {
        return actions.Aggregate(new TSubject(), (subject, action) => action(subject));
    }
}

// Builder selado
public sealed class CarBuilder : GenericFuncionalBuilder<Car, CarBuilder>
{
    public CarBuilder Brand(string brand)
    {
        return Do(c => c.Brand = brand);
    }
    
    public CarBuilder Model(string model)
    {
        return Do(c => c.Model = model);
    }
}

// Extensão
public static class CarBuilderExtensions
{
    public static CarBuilder Price(this CarBuilder carBuilder, float price)
    {
        return carBuilder.Do(c => c.Price = price);
    }
}