using System.Text;

// Demo with builder
var builder = new HtmlBuilder("ul")
    .AddChild("li", "c#")
    .AddChild("li", "Java")
    .Build(); // Returns HtmlElement

Console.WriteLine(builder);

// Demo without builder
var element = new HtmlElement("ul");
element.Elements.Add(new HtmlElement("li", "Go"));
element.Elements.Add(new HtmlElement("li", "Flutter"));

Console.WriteLine(element);

// Classe a ser construída
public class HtmlElement
{
    private const int IndentSize = 2;
    
    public string Name { get; set; }

    public string Text { get; set; }

    public List<HtmlElement> Elements = new();

    public HtmlElement()
    {
        
    }

    public HtmlElement(string name, string text)
    {
        Name = name;
        Text = text;
    }
    
    public HtmlElement(string name)
    {
        Name = name;
    }

    private string ToStringImpl(int indent)
    {
        var sb = new StringBuilder();
        var baseIndent = new string(' ', IndentSize * indent);
        
        sb.AppendLine($"{baseIndent}<{Name}>");

        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', IndentSize * (indent + 1)));
            sb.AppendLine(Text);
        }

        foreach (var element in Elements)
        {
            sb.Append(element.ToStringImpl(indent + 1));
        }

        sb.AppendLine($"{baseIndent}</{Name}>");

        return sb.ToString();
    }

    public override string ToString()
    {
        return ToStringImpl(0);
    }
}


// Builder
public class HtmlBuilder
{
    private string _rootName;

    private HtmlElement _root = new HtmlElement();

    public HtmlBuilder(string rootName)
    {
        _rootName = rootName;
        _root.Name = rootName;
    }

    public HtmlBuilder AddChild(string childName, string childText)
    {
        var element = new HtmlElement(childName, childText);
        _root.Elements.Add(element);

        // Fluent 
        return this;
    }

    public override string ToString()
    {
        return _root.ToString();
    }

    public HtmlElement Build()
    {
        return _root;
    }
    
    public void Clear()
    {
        _root = new HtmlElement { Name = _rootName };
    }
}