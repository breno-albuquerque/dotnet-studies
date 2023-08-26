// Demo
var car = CarBuilder.Create()
    .OfType(CarType.Crossover)
    .WithWheels(10)
    .Build();

Console.WriteLine(car);

// Classe a ser construída
public class Car
{
    public CarType Type { get; set; }
    
    public int WheelSize { get; set; }

    public override string ToString()
    {
        return $"{nameof(Type)}: {Type}, {nameof(WheelSize)}: {WheelSize}";
    }
}

// Builder que expões método de criação
public class CarBuilder
{
    public static ICarType Create() => new CarBuilderImpl();
    
    // Implementação do Builder
    private class CarBuilderImpl : ICarType, IWheelSize, ICarBuilder 
    {
        private Car car => new();
        
        public IWheelSize OfType(CarType type)
        {
            car.Type = type;
            return this;
        }

        public ICarBuilder WithWheels(int size)
        {
            if (car.Type == CarType.Sedan && size is > 25)
                throw new Exception("Invalid wheels size");

            car.WheelSize = size;
            return this;
        }

        public Car Build()
        {
            return car;
        }
    }
}


//  Interfaces segregadas
public interface ICarType
{
    IWheelSize OfType(CarType type);
}

public interface IWheelSize
{
    ICarBuilder WithWheels(int size);
}

public interface ICarBuilder
{
    Car Build();
}

// Tipo de carro
public enum CarType
{
    Crossover = 1,
    Sedan = 2
}