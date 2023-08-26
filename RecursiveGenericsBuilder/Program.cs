// Demo
var newYork = new CityBuilder()
    .SetCountry("United States")
    .SetState("New York")
    .SetPopulation(8000000)
    .Build();

Console.WriteLine(newYork);

// Classe a ser construída
public class City
{
    public string Country { get; set; }

    public string State { get; set; }
    
    public long Population { get; set; }

    public override string ToString()
    {
        return $"{nameof(Country)}: {Country}, {nameof(State)}: {State}, {nameof(Population)}: {Population}";
    }
}

// Builder abstrato
public abstract class BaseCityBuilder
{
    protected City city = new City();

    public City Build() => city;
}

//  Primeiro builder genérico
public class CityCountryBuilder<T> : BaseCityBuilder
    where T : CityCountryBuilder<T>
{
    public T SetCountry(string country)
    {
        city.Country = country;
        return (T)this;
    }
}

// Segundo builder genérico
public class CityStateBuilder<T> : CityCountryBuilder<CityStateBuilder<T>>
    where T : CityStateBuilder<T>
{
    public T SetState(string state)
    {
        city.State = state;
        return (T)this;
    }
}

// Terceiro builder genérico
public class CityPopulationBuilder<T> : CityStateBuilder<CityPopulationBuilder<T>>
    where T : CityPopulationBuilder<T>
{
    public T SetPopulation(long population)
    {
        city.Population = population;
        return (T)this;
    }
}

// Builder para ser instanciado e expor o objeto
public class CityBuilder : CityPopulationBuilder<CityBuilder>
{
    public CityBuilder New => new();
} 





