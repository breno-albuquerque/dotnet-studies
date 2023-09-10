// Código cliente depende apenas da abstração
IDrawer pen = new Pen();
IDrawer pencil = new Pencil();

Shape squarePen = new Square(pen);
Shape squarePencil = new Square(pencil);
Shape circlePen = new Circle(pen);
Shape circlePencil = new Circle(pencil);

var client1 = new Client(squarePen);
var client2 = new Client(squarePencil);
var client3 = new Client(circlePen);
var client4 = new Client(circlePencil);

client1.DrawShape();
client2.DrawShape();
client3.DrawShape();
client4.DrawShape();

// Código cliente depende apenas da Abstração
public class Client
{
    private readonly Shape _shape;
    
    public Client(Shape shape)
    {
        _shape = shape;
    }

    public void DrawShape()
    {
        var type = _shape.GetType();
        
        Console.Write($"Drawing Shape {type} and ");
        
        _shape.Draw();
    }
}

// Abstração (conceito != de abstract class ou interface)
public abstract class Shape
{
    protected readonly IDrawer _drawer;

    protected Shape(IDrawer drawer)
    {
        _drawer = drawer;
    }

    public abstract void Draw();
}

public class Circle : Shape
{
    public Circle(IDrawer drawer) : base(drawer)
    {
    }

    public override void Draw()
    {
        _drawer.Draw();
    }
}

public class Square : Shape
{
    public Square(IDrawer drawer) : base(drawer)
    {
    }

    public override void Draw()
    {
        _drawer.Draw();
    }
}

// Implementação (conceito != de classes que implementação abstract class ou interfaces)
public interface IDrawer
{
    void Draw();
}

public class Pen : IDrawer
{
    public void Draw()
    {
        Console.WriteLine($"Drawing with {nameof(Pen)}");
    }
}

public class Pencil : IDrawer
{
    public void Draw()
    {
        Console.WriteLine($"Drawing with {nameof(Pencil)}");
    }
}
