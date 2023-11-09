// Demo
var phone = new Phone("55", "00", "1234-1234");

// Conversão implícita (sem explicitar para o compilador)
string stringPhone = phone;
Console.WriteLine($"Type - {stringPhone.GetType()} - {stringPhone}");

// Conversão implícita (sem explicitar para o compilador)
Phone objectPhone = stringPhone;
Console.WriteLine($"Type - {objectPhone.GetType()} - {objectPhone}");


public class Phone
{
    public string CountryCode { get; }
    public string Area { get; }
    public string Number { get; }
    
    public Phone(string countryCode, string area, string number)
    {
        CountryCode = countryCode;
        Area = area;
        Number = number;
    }

    // Permite converter Phone para String de forma implícita
    public static implicit operator string(Phone phone) => $"+{phone.CountryCode} ({phone.Area}) {phone.Number}";
    
    // Permite converter string para Phone de forma implícita
    public static implicit operator Phone(string phone)
    {
        var data = phone.Split(" ");
        return new Phone(data[0], data[1], data[2]);
    }
}