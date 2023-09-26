using System.Text;

// Decorating by Size
var baseSizebleCircle = new Circle();
Console.WriteLine(baseSizebleCircle.AsString());

var bigCircle = new SizebleShape(baseSizebleCircle, Size.Big);
Console.WriteLine(bigCircle.AsString());

try
{
    var bigAndSmallCircle = new SizebleShape(bigCircle, Size.Small); // Throws due to NoCycleAllowed policy
}
catch (Exception ex)
{
    Console.WriteLine($"Shape not allowed due to: {ex.Message}");
}

// Decorating by Color
var baseColorableCircle = new Circle();
Console.WriteLine(baseColorableCircle.AsString());

var yellowCircle = new ColoredShape(baseColorableCircle, Color.Yellow);
Console.WriteLine(yellowCircle.AsString());

var yellowAndBlueCircle = new ColoredShape(yellowCircle, Color.Blue); // Allowed due to AllCyclesAllowed policy
Console.WriteLine(yellowAndBlueCircle.AsString());


// Different Decorators
var bigYellowCircle = new ColoredShape(bigCircle, Color.Yellow); // With different types the NoCycleAllowed policy accepts
Console.WriteLine(bigYellowCircle.AsString());

public abstract class Shape
{
    public abstract string AsString();
}

public sealed class Circle : Shape
{
    public Circle()
    {
    }

    public override string AsString() =>
        $"I'm a {nameof(Circle)}";
}

// Política de ciclos decorator (abstrato)
public interface IShapeDecoratorCyclePolicy
{
    public bool IsNewDecoratorTypeAllowed(Type type, IList<Type> allTypes);
}

// Política de ciclos decorator (exemplo de implementação)
public class NoCycleAllowed : IShapeDecoratorCyclePolicy
{
    private const string CycleMessage = "Decorator cycle detected";
    
    public bool IsNewDecoratorTypeAllowed(Type type, IList<Type> allTypes)
    {
        if (!allTypes.Contains(type)) return true; 

        throw new InvalidOperationException(CycleMessage);
    }
}

public class AllCyclesAllowed : IShapeDecoratorCyclePolicy
{
    public bool IsNewDecoratorTypeAllowed(Type type, IList<Type> allTypes) => true;
}

// Base class 1 para Decorator
public abstract class ShapeDecorator : Shape
{
    protected Shape Shape { get; }

    protected List<Type> AllDecoratorsOnShape { get; } = new();

    protected ShapeDecorator(Shape shape)
    {
        Shape = shape;
        
        if (shape is ShapeDecorator shapeDecorator)
            AddCurrentDecorators(shapeDecorator);
    }

    private void AddCurrentDecorators(ShapeDecorator shapeDecorator)
    {
        AllDecoratorsOnShape.AddRange(shapeDecorator.AllDecoratorsOnShape);
    }
}

// Base class 2 para Decorator
public abstract class ShapeDecoratorWithPolicy<TSelf, TPolicy> : ShapeDecorator
    where TPolicy : IShapeDecoratorCyclePolicy, new()
{
    private readonly IShapeDecoratorCyclePolicy _policy = new TPolicy();
    
    protected ShapeDecoratorWithPolicy(Shape shape) : base(shape)
    {
        var canApply = _policy.IsNewDecoratorTypeAllowed(typeof(TSelf), AllDecoratorsOnShape);

        if (canApply) AllDecoratorsOnShape.Add(typeof(TSelf));
        // else exceção será lançada
    }
}

// Decorator de tamanho
public class SizebleShape : ShapeDecoratorWithPolicy<SizebleShape, NoCycleAllowed>
{
    private readonly Size _size;
    
    public SizebleShape(Shape shape, Size size) : base(shape)
    {
    }

    public override string AsString()
    {
        var builder = new StringBuilder();

        builder.Append(Shape.AsString());
        builder.Append($" of size {_size}");

        return builder.ToString();
    }
}

// Decorator de cor
public class ColoredShape : ShapeDecoratorWithPolicy<ColoredShape, AllCyclesAllowed>
{
    private readonly Color _color;
    
    public ColoredShape(Shape shape, Color color) : base(shape)
    {
        _color = color;
    }

    public override string AsString()
    {
        var builder = new StringBuilder();

        builder.Append(Shape.AsString());
        builder.Append($" with color {_color}");

        return builder.ToString();
    }
}



public enum Color
{
    Blue = 1,
    Yellow = 2,
}

public enum Size
{
    Small = 0,
    Medium = 1,
    Big = 2
}



