using System.Collections.ObjectModel;

// Demo
var rectangle = new Rectangle(0, 0, 10, 10);

var pointDrawer = new PointDrawer();

foreach (var line in rectangle)
{
    foreach (var point in new LineToPointsAdapter(line))
    {
        pointDrawer.Draw(point);
    }
}

// Nossa interface desenha apenas pontos
public interface IPointDrawer
{
    public void Draw(Point point);
}

public class PointDrawer : IPointDrawer
{
    public void Draw(Point point)
    {
        Console.WriteLine($"X: {point.X}, Y: {point.Y}");
    }
}

// Adaptador que converte linhas para pontos
public class LineToPointsAdapter : Collection<Point>
{
    public LineToPointsAdapter(Line line)
    {
        int left = Math.Min(line.Start.X, line.End.X);
        int right = Math.Max(line.Start.X, line.End.X);
        int top = Math.Min(line.Start.Y, line.End.Y);
        int bottom = Math.Max(line.Start.Y, line.End.Y);
        
        int dx = right - left;
        int dy = line.End.Y - line.Start.Y;
        
        if (dx == 0)
        {
            for (int y = top; y <= bottom; ++y)
            {
                Add(new Point(left, y));
            }
        } 
        else if (dy == 0)
        {
            for (int x = left; x <= right; ++x)
            {
                Add(new Point(x, top));
            }
        }
    }
}

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Line
{
    public Point Start { get; set; }
    public Point End { get; set; }

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }
}

public class Rectangle : Collection<Line>
{
    public Rectangle(int x, int y, int width, int height)
    {
        var bottomLeft = new Point(x, y);
        var topLeft = new Point(x, y + height);
        var topRight = new Point(x + width, y + height);
        var bottomRight = new Point(x + width, y);
        
        Add(new Line(bottomLeft, bottomRight));
        Add(new Line(bottomRight, topRight));
        Add(new Line(topRight, topLeft));
        Add(new Line(topLeft, bottomLeft));
    }
}