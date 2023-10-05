using System.Text;

// Demo
var libClass1 = new LibClass1();
var libClass2 = new LibClass2();

var libFacade = new LibFacade(libClass1, libClass2);

var facadeResult = libFacade.Execute();

Console.WriteLine(facadeResult);

// Facade
public class LibFacade
{
    private readonly LibClass1 _libClass1;
    private readonly LibClass2 _libClass2;

    public LibFacade(LibClass1 libClass1, LibClass2 libClass2)
    {
        _libClass1 = libClass1;
        _libClass2 = libClass2;
    }

    public string Execute()
    {
        var builder = new StringBuilder();

        builder.AppendLine(_libClass1.Operation1());

        builder.AppendLine(_libClass1.Operation2());

        builder.AppendLine(_libClass2.Operation1());

        builder.AppendLine(_libClass2.Operation2());

        return builder.ToString();
    }
}

// Biblioteca Fictícia
public class LibClass1
{
    public string Operation1()
    {
        return $"{nameof(LibClass1)}: Executing {nameof(Operation1)}";
    }
    
    public string Operation2()
    {
        return $"{nameof(LibClass1)}: Executing {nameof(Operation2)}";
    }
}

public class LibClass2
{
    public string Operation1()
    {
        return $"{nameof(LibClass2)}: Executing {nameof(Operation1)}";
    }
    
    public string Operation2()
    {
        return $"{nameof(LibClass2)}: Executing {nameof(Operation2)}";
    }
}