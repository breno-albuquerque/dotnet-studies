using FluentBuilder;

// With builder
var builder = new HtmlBuilder("ul")
    .AddChild("li", "c#")
    .AddChild("li", "Java")
    .Build(); // Returns HtmlElement

// Without builder
var element = new HtmlElement("ul");
element.Elements.Add(new HtmlElement("li", "Go"));
element.Elements.Add(new HtmlElement("li", "Flutter"));

Console.WriteLine(builder);
Console.WriteLine(element);