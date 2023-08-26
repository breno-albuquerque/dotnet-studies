using System.Text;

// Demo
var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
Console.WriteLine(cb);

public class CodeBuilder
{
    private readonly string _className;

    private readonly Dictionary<string, string> _fields = new();

    public CodeBuilder(string className)
    {
        _className = className;
    }

    public CodeBuilder AddField(string name, string type)
    {
        _fields.Add(type, name);
        return this;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        
        sb.AppendLine($"public class {_className}").AppendLine("{");

        foreach (var pair in _fields)
        {
            sb.AppendLine($"  public {pair.Key} {pair.Value};");
        }

        sb.AppendLine("}");

        return sb.ToString();
    }
}