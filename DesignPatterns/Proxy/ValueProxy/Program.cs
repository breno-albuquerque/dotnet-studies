// Demo
Console.WriteLine(10f * 5.Percent());
Console.WriteLine(50.Percent() * 50.Percent());

// Proxy para um valor float.
public readonly struct Percentage
{
    private readonly float _value;

    public Percentage(float value)
    {
        _value = value;
    }

    public static float operator *(float f, Percentage p) => f * p._value;
    
    public static Percentage operator *(Percentage p1, Percentage p2) => new(p1._value *  p2._value);

    public override string ToString() => $"{_value * 100}%";
}

public static class PercentageExtensions
{
    public static Percentage Percent(this int value) => new(value / 100.0f);
}


