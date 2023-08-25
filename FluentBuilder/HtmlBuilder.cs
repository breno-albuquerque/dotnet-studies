namespace BasicBuilder;

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