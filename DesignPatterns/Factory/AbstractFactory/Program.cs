// Demo
var healthyClient = new Client(new HealthyDrinkAbstractFactory());
var unhealthyClient = new Client(new TastyDrinkAbstractFactory());
var sleepyClient = new Client(new EnergyDrinkAbstractFactory());

Console.WriteLine("On a hot day health client " + healthyClient.ColdDrink.Consume());
Console.WriteLine("On a hot day unhealthy client " + unhealthyClient.ColdDrink.Consume());
Console.WriteLine("On a hot day sleepy client " + sleepyClient.ColdDrink.Consume());

//  Contratos das classes a serem construídas
public interface IHotDrink
{
    string Consume();
}

public interface IColdDrink
{
    string Consume();
}

// Conjunto de classes relacionadas a IHotDrink
public class Tea : IHotDrink
{
    public string Consume() => "consumed tea";
}

public class Coffe : IHotDrink
{
    public string Consume() => "consumed coffe";
}

public class HotChocolate : IHotDrink
{
    public string Consume() => "consumed hot chocolate";
}

// Conjunto de classes relacionadas a IColdDrink
public class Water : IColdDrink
{
    public string Consume() => "consumed water";
}

public class RedBull : IColdDrink
{
    public string Consume() => "consumed red bull";
}

public class CocaCola : IColdDrink
{
    public string Consume() => "consumed coca cola";
}

// Contrato da Factory
public interface IDrinkAbstractFactory
{
    IHotDrink CreateHotDrink();
    IColdDrink CreateColdDrink();
}

// Implementações das factories
public class HealthyDrinkAbstractFactory : IDrinkAbstractFactory
{
    public IHotDrink CreateHotDrink() => new Tea();

    public IColdDrink CreateColdDrink() => new Water();
}

public class EnergyDrinkAbstractFactory : IDrinkAbstractFactory
{
    public IHotDrink CreateHotDrink() => new Coffe();

    public IColdDrink CreateColdDrink() => new RedBull();
}

public class TastyDrinkAbstractFactory : IDrinkAbstractFactory
{
    public IHotDrink CreateHotDrink() => new HotChocolate();

    public IColdDrink CreateColdDrink() => new CocaCola();
}

// Cliente depende apenas da AbstractFactory
public class Client
{
    public IHotDrink HotDrink { get; set; }
    public IColdDrink ColdDrink { get; set; }

    public Client(IDrinkAbstractFactory factory)
    {
        HotDrink = factory.CreateHotDrink();
        ColdDrink = factory.CreateColdDrink();
    }
}


