// Demo
var person = new Person();
var hospital = new Hospital();

// Subscription retorna IDisposable, o que permite controle que a KeyWord Event não fornece
using var subscription = person.Subscribe(hospital); 

person.FallsIll();

public class Event
{
    
}

public class FallsIllEvent : Event
{
    public string Address { get; set; }
}

public class Person : IObservable<Event> // Publisher
{
    private readonly HashSet<Subscription> _subscriptions = new();

    public void FallsIll()
    {
        foreach (var subscription in _subscriptions)
        {
            subscription.Observer.OnNext(new FallsIllEvent(){Address = "New York Street 1000"});
        }
    }
    
    public IDisposable Subscribe(IObserver<Event> observer)
    {
        var subscription = new Subscription(this, observer);

        _subscriptions.Add(subscription);

        return subscription;
    }
    
    private class Subscription : IDisposable
    {
        private readonly Person _person;
        public readonly IObserver<Event> Observer;

        public Subscription(Person person, IObserver<Event> observer)
        {
            _person = person;
            Observer = observer;
        }
        
        public void Dispose()
        {
            _person._subscriptions.Remove(this);
        }
    }
}

public class Hospital : IObserver<Event> // Subscriber
{
    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(Event value)
    {
        if (value is FallsIllEvent args)
            Console.WriteLine($"Sending doctor to {args.Address}");
    }
}