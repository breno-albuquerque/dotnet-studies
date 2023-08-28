// Demo
var point = Point.NewCartesianPoint(10, 10);
var sandero = CarFactory.NewCrossOverCar("sandero");
var foo = await Foo.CreateAsync();
var result = ProcessResult.Factory.CreateSuccessResult(10, "Success");

// Factory Method
public class Point
{
    public double X { get; set; }
    public double Y { get; set; }
    
    private Point(double x, double y)
    {
        X = x;
        Y = y;
    }
    
    public static Point NewCartesianPoint(double x, double y) 
        => new(x, y); 
    
    public static Point NewPolarPoint(double rho, double theta) 
        => new(rho * Math.Cos(theta), rho * Math.Sin(theta));
}

// Factory class
public class Car
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Car(string name, string type)
    {
        
    }
}
public class CarFactory
{
    public static Car NewSedanCaer(string name) => new(name, "sedan");

    public static Car NewCrossOverCar(string name) => new(name, "crossover");
}

// Inner Factory
public class ProcessResult
{
    public bool Success { get; set; }
    public int Score { get; set; }
    public string Content { get; set; }

    private ProcessResult(int score, bool success, string content)
    {
        Success = success;
        Score = score;
        Content = content;
    }

    public static class Factory
    {
        public static ProcessResult CreateFailureResult(int score) 
            => new ProcessResult(score, false, null!);
        
        public static ProcessResult CreateSuccessResult(int score, string content) 
            => new ProcessResult(score, true, content);
    }
}

// Asynchronous Object Creation
public class Foo
{
    private Foo()
    {
        
    }

    private async Task<Foo> InitAsync()
    {
        await Task.Delay(30000);
        return this;
    }

    public static Task<Foo> CreateAsync()
    {
        var foo = new Foo();
        return foo.InitAsync();
    }
}

