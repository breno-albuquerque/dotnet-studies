using System.Text;

namespace BasicBuilder;

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