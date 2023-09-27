var printer = new Printer();
printer.Print("var printer = new Printer();var printer2 = new Printer();");

var lineBreakerPrinter = new LineBreakerPrinter(printer, ';');
lineBreakerPrinter.Print("var printer = new Printer();var printer2 = new Printer();");

public interface IPrinter
{
    void Print(string text);
}

public class Printer : IPrinter
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}

// Decorator
public class LineBreakerPrinter : IPrinter
{
    private readonly IPrinter _decorated;
    private readonly char _lineDelimiter;

    public LineBreakerPrinter(IPrinter decorated, char lineDelimiter)
    {
        _decorated = decorated;
        _lineDelimiter = lineDelimiter;
    }

    public void Print(string text)
    { 
        var phrases = text.Split(_lineDelimiter, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var phrase in phrases)
        {
            _decorated.Print($"{phrase}{_lineDelimiter}");
        }
    }
}

