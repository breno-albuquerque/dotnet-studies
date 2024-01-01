// Demo
var person = new Person();
var hospital = new Hospital();

person.FallsIllEvent += hospital.TakeCare;

person.FallsIll(new IllArgs() {type = IllType.Allergy});

public class IllArgs : EventArgs 
{
    public IllType type { get; set; }
}

public class Person // Publisher
{
    public event EventHandler<EventArgs> FallsIllEvent;

    public void FallsIll(IllArgs arg)
    {
        FallsIllEvent?.Invoke(this, arg);
    }
}

public class Hospital // Subscriber 
{
    public void TakeCare(object? source, EventArgs args)
    {
        Console.WriteLine($"Calling a doctor speciliazed in: {((IllArgs)args).type}");
    }
}

public enum IllType
{
    Infectious,
    Physiological,
    Allergy
}