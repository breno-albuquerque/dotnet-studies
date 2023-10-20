var carType1 = CarTypeFactory.GetCarType("Peugeot", "208");
var carType2 = CarTypeFactory.GetCarType("Lamborghini", "Urus");
var carType3 = CarTypeFactory.GetCarType("Lamborghini", "Urus");

var car1 = new Car(150, "Belo Horizonte", "New York", carType1);
var car2 = new Car(200, "Belo Horizonte", "New York", carType2);
var car3 = new Car(200, "Belo Horizonte", "New York", carType3);

Console.WriteLine("Reference Equals CarType1 & CarType2: " + ReferenceEquals(car1.CarType, car2.CarType));
Console.WriteLine("Reference Equals CarType2 & CarType3: " + ReferenceEquals(car2.CarType, car3.CarType));

Console.WriteLine(car1.Move());
Console.WriteLine(car2.Move());
Console.WriteLine(car3.Move());

// Objeto Flyweight (Possui o estado intrínseco)
public class CarType
{
    public string Brand { get; }

    public string Model { get; }
    

    public CarType(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }

    // Recebe o estado extrínseco via parâmetros
    public string Move(float speed, string from, string to)
        => $"Car {Brand} {Model} moving at {speed} kilometers per hour from {from} to {to}";
}

public class Car
{
    public float Speed { get; }

    public string Location { get; }

    public string Destination { get; }

    public CarType CarType { get; }

    public Car(float speed, string location, string destination, CarType carType)
    {
        Speed = speed;
        Location = location;
        Destination = destination;
        CarType = carType;
    }

    public string Move() => CarType.Move(Speed, Location, Destination);
}

// Factory para decidir se reutilizará o CarType ou criará um novo
public static class CarTypeFactory
{  
    private static readonly List<CarType> _carTypes = new();  
	  
    public static CarType GetCarType(string brand, string model)
    {
        var carType = _carTypes.Find((carType) => carType.Brand == brand && carType.Model == model);

        if (carType is null)
        {
            carType = new CarType(brand, model);
            _carTypes.Add(carType);
        }
        
        return carType;
    }  
}