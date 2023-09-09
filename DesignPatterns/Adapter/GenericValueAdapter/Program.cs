// Queremos representar vetores:
// N tipos (integers, decimal...)
// N dimensões (2, 3...)

// Demo

var v = new Vector2i(5, 5);
var vv = new Vector2i(10, 25);

var sum = v + vv;

Console.WriteLine("Sum: " + sum);

// GENERIC VALUE ADAPTER (start)
// Eenables us to get a integer thourgh a generic type doing new IIntergerImpl.Value
public interface IInterger
{
    int Value { get; }
}

// wrapper to IIntegers
public class Dimensions
{
    // Genric Value Adapter Implementation
    public class Two : IInterger
    {
        public int Value => 2;
    }
    
    // Genric Value Adapter Implementation
    public class Three : IInterger
    {
        public int Value => 3;
    }
}
// GENERIC VALUE ADAPTER (end)

// Generic Vector to be inherited
public class Vector<T, D>
    where D : IInterger, new()
{
    protected T[] data;

    public Vector()
    {
        // Utilização do generic value adapter. UTilizamos o tipo D para pegar o valor literal 3
        data = new T[new D().Value];
    }

    public Vector(params T[] values)
    {
        var requiredSize = new D().Value;
        data = new T[requiredSize];

        var providedSize = values.Length;

        for (int i = 0; i < Math.Min(requiredSize, providedSize); i++)
            data[i] = values[i];
    }

    public T this[int index]
    {
        get => data[index];
        set => data[index] = value;
    }

    public T X
    {
        get => data[0];
        set => data[0] = value;
    }
}

// Vector Of Int
public class VectorOfInt<D> : Vector<int, D>
    where D : IInterger, new()
{
    public VectorOfInt()
    {
    }

    public VectorOfInt(params int[] values) : base(values)
    {
    }

    public static VectorOfInt<D> operator +(VectorOfInt<D> lhs, VectorOfInt<D> rhs)
    {
        var result = new VectorOfInt<D>();
        var dim = new D().Value;

        for (int i = 0; i < dim; i++)
        {
            result[i] = lhs[i] + rhs[i];
        }

        return result;
    }
    
    public override string ToString()
    {
        return $"{string.Join(", ", data)}";
    }
}

// Vector Of Float
public class VectorOfFloat<D> : Vector<float, D>
    where D : IInterger, new()
{
    public VectorOfFloat()
    {
    }

    public VectorOfFloat(params float[] values) : base(values)
    {
    }
    
    public static VectorOfFloat<D> operator +(VectorOfFloat<D> lhs, VectorOfFloat<D> rhs)
    {
        var result = new VectorOfFloat<D>();
        var dim = new D().Value;

        for (int i = 0; i < dim; i++)
        {
            result[i] = lhs[i] + rhs[i];
        }

        return result;
    }
    public override string ToString()
    {
        return $"{string.Join(", ", data)}";
    }
    
}

public class Vector3f : VectorOfFloat<Dimensions.Three>
{
    public Vector3f()
    {
    }

    public Vector3f(params float[] values) : base(values)
    {
    }
}


public class Vector2i : VectorOfInt<Dimensions.Two>
{
    public Vector2i()
    {
    }

    public Vector2i(params int[] values) : base(values)
    {
    }
}