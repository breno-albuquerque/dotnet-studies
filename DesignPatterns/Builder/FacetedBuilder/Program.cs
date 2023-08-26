// Demo
var ouroMinasHotel = new HotelBuilderFacade()
    .IsLocated
        .OnCity("Belo Horizonte")
        .OnStreet("Cristiano Machado")
        .WithNumber(4001)
    .Offers
        .CleaningServiceBetween(10, 18)
        .RestaurantServiceBetween(6, 22)
    .Build();

Console.WriteLine("Ouro Minas Hotel: " + ouroMinasHotel);

// Classe a ser construída
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

// Façade - Fachada
public class HotelBuilderFacade 
{
    protected Hotel Hotel { get; set; } = new Hotel();

    public LocationBuilderFacade IsLocated => new LocationBuilderFacade(Hotel);

    public ServiceBuilderFacade Offers => new ServiceBuilderFacade(Hotel);

    public Hotel Build() => Hotel;
}

// Location Builder
public class LocationBuilderFacade : HotelBuilderFacade
{
    public LocationBuilderFacade(Hotel hotel)
    {
        Hotel = hotel;
    }
    
    public LocationBuilderFacade OnCity(string city)
    {
        Hotel.City = city;
        return this;
    }
    
    public LocationBuilderFacade OnStreet(string street)
    {
        Hotel.Street = street;
        return this;
    }
    
    public LocationBuilderFacade WithNumber(int number)
    {
        Hotel.Number = number;
        return this;
    }
}

// Service Builder
public class ServiceBuilderFacade : HotelBuilderFacade
{
    public ServiceBuilderFacade(Hotel hotel)
    {
        Hotel = hotel;
    }
    
    public ServiceBuilderFacade CleaningServiceBetween(int startHour, int endHour)
    {
        Hotel.CleaningServiceStartHour = startHour;
        Hotel.CleaningServiceEndHour = endHour;
        return this;
    }

    public ServiceBuilderFacade RestaurantServiceBetween(int openHour, int endHour)
    {
        Hotel.RestaurantServiceOpenHour = openHour;
        Hotel.RestaurantServiceCloseHour = endHour;
        return this;
    }
}