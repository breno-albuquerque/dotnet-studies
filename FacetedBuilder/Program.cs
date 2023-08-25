var ouroMinasHotel = new HotelBuilder()
    .IsLocated()
        .OnCity("Belo Horizonte")
        .OnStreet("Cristiano Machado")
        .WithNumber(4001)
    .Offers()
        .CleaningServiceBetween(10, 18)
        .RestaurantServiceBetween(6, 22)
    .Build();

Console.WriteLine("Ouro Minas Hotel: " + ouroMinasHotel);
    
public class Hotel
{
    // location
    public string City { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    
    // services
    public int CleaningServiceStartHour { get; set; }
    public int CleaningServiceEndHour { get; set; }
    public int RestaurantServiceOpenHour { get; set; }
    public int RestaurantServiceCloseHour { get; set; }

    public override string ToString()
    {
        return $"{nameof(City)}: {City}, {nameof(Street)}: {Street}, {nameof(Number)}: {Number}, {nameof(CleaningServiceStartHour)}: {CleaningServiceStartHour}, {nameof(CleaningServiceEndHour)}: {CleaningServiceEndHour}, {nameof(RestaurantServiceOpenHour)}: {RestaurantServiceOpenHour}, {nameof(RestaurantServiceCloseHour)}: {RestaurantServiceCloseHour}";
    }
}

public class HotelBuilder // Façade (Fachada)
{
    protected Hotel Hotel { get; set; } = new Hotel();

    public LocationBuilder IsLocated() => new LocationBuilder(Hotel);

    public ServiceBuilder Offers() => new ServiceBuilder(Hotel);

    public Hotel Build() => Hotel;
}

public class LocationBuilder : HotelBuilder
{
    public LocationBuilder(Hotel hotel)
    {
        Hotel = hotel;
    }
    
    public LocationBuilder OnCity(string city)
    {
        Hotel.City = city;
        return this;
    }
    
    public LocationBuilder OnStreet(string street)
    {
        Hotel.Street = street;
        return this;
    }
    
    public LocationBuilder WithNumber(int number)
    {
        Hotel.Number = number;
        return this;
    }
}

public class ServiceBuilder : HotelBuilder
{
    public ServiceBuilder(Hotel hotel)
    {
        Hotel = hotel;
    }
    
    public ServiceBuilder CleaningServiceBetween(int startHour, int endHour)
    {
        Hotel.CleaningServiceStartHour = startHour;
        Hotel.CleaningServiceEndHour = endHour;
        return this;
    }

    public ServiceBuilder RestaurantServiceBetween(int openHour, int endHour)
    {
        Hotel.RestaurantServiceOpenHour = openHour;
        Hotel.RestaurantServiceCloseHour = endHour;
        return this;
    }
}