var car = CarBuilder.Create()
    .OfType(CarType.Crossover)
    .WithWheels(10)
    .Build();

public class CarBuilder
{
    public static ICarType Create() => new CarBuilderImpl();
    
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

public class Car
{
    public CarType Type { get; set; }
    
    public int WheelSize { get; set; }
}

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

public enum CarType
{
    Crossover = 1,
    Sedan = 2
}