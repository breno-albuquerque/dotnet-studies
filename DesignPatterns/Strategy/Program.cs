using System.Text;

// Demo
var items = new string[] { "Item 1", "Item 2", "Item 3" };

var textProcessor = new TextProcessor(new HtmlListStrategy());
textProcessor.AppendList(items);
var html = textProcessor.ToString();

textProcessor.Clear();

textProcessor.SetStrategy(new MarkdownListStrategy());
textProcessor.AppendList(items);
var markdown = textProcessor.ToString();

Console.WriteLine("Html: ");
Console.WriteLine(html);

Console.WriteLine("Markdown: ");
Console.WriteLine(markdown);

public interface IListStrategy // Strategy interface
{
    void Start(StringBuilder sb);

    void End(StringBuilder sb);

    void AddListItem(StringBuilder sb, string item);
}

public class HtmlListStrategy : IListStrategy // Concrete strategy
{
    public void Start(StringBuilder sb)
    {
        sb.AppendLine("<ul>");
    }

    public void End(StringBuilder sb)
    {
        sb.AppendLine("</ul>");
    }

    public void AddListItem(StringBuilder sb, string item)
    {
        sb.AppendLine($"  <li>{item}</li>");
    }
}

public class MarkdownListStrategy : IListStrategy // Concrete strategy
{
    public void Start(StringBuilder sb)
    {
    }

    public void End(StringBuilder sb)
    {
    }

    public void AddListItem(StringBuilder sb, string item)
    {
        sb.AppendLine($" - {item}");
    }
}

public class TextProcessor // Context
{
    private IListStrategy _strategy;

    private StringBuilder _text = new();

    public TextProcessor(IListStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IListStrategy strategy) => _strategy = strategy;

    public void AppendList(IEnumerable<string> items)
    {
        _strategy.Start(_text);
        
        foreach (var item in items)
        {
            _strategy.AddListItem(_text, item);
        }
        
        _strategy.End(_text);
    }

    public void Clear() => _text.Clear();

    public override string ToString() => _text.ToString();
}