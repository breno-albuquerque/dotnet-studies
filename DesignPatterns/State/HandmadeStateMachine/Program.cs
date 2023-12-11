// Demo
var rules = Rules.Get;

var state = State.OffHook;

while (true)
{
    Console.WriteLine($"The phone is currently {state}");
    Console.WriteLine("Select a trigger:");
    
    for (var i = 0; i < rules[state].Count; i++)
    {
        var (t, _) = rules[state][i];
        Console.WriteLine($"{i}. {t}");
    }
    
    int input = int.Parse(Console.ReadLine());

    var (_, s) = rules[state][input];
    state = s;
}

public static class Rules
{
    // Utilizando uma estrutura de dados para guardas as regras
    public static Dictionary<State, List<(Trigger, State)>> Get = new()
    {
        [State.OffHook] = new()
        {
            (Trigger.CallDialed, State.Connecting)
        },
        [State.Connecting] = new()
        {
            (Trigger.HungUp, State.OffHook),
            (Trigger.CallConnected, State.Connected)
        },
        [State.Connected] = new()
        {
            (Trigger.LeftMessage, State.OffHook),
            (Trigger.HungUp, State.OffHook),
            (Trigger.PlacedOnHold, State.OnHold)
        },
        [State.OnHold] = new()
        {
            (Trigger.TakenOffHold, State.Connected),
            (Trigger.HungUp, State.OffHook)
        }
    };
}

public enum State
{
    OffHook,
    Connecting,
    Connected,
    OnHold
}

public enum Trigger
{
    CallDialed,
    HungUp,
    CallConnected,
    PlacedOnHold,
    TakenOffHold,
    LeftMessage
}



