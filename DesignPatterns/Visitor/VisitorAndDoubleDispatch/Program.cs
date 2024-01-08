// Demo
var visitor1 = new ConcreteVisitor1();
var visitor2 = new ConcreteVisitor2();

var componentA = new ConcreteComponentA();
var componentB = new ConcreteComponentB();

componentA.Accept(visitor1);
componentA.Accept(visitor2);
componentB.Accept(visitor1);
componentB.Accept(visitor2);

// Isso geraria erro:
// BaseComponent component = new ConcreteComponentA();
// visitor1.Visit(component);

public interface IComponent
{
    void Accept(IVisitor visitor);
}

public abstract class BaseComponent
{
    public abstract void Accept(IVisitor visitor);
}

public class ConcreteComponentA : BaseComponent
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this); // double dipatch
    }
    public string ExclusiveMethodOfConcreteComponentA()
    {
        return "A";
    }
}

public class ConcreteComponentB : BaseComponent
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this); // double dipatch
    }

    public string SpecialMethodOfConcreteComponentB()
    {
        return "B";
    }
}

public interface IVisitor
{
    void Visit(ConcreteComponentA element);

    void Visit(ConcreteComponentB element);
}

class ConcreteVisitor1 : IVisitor
{
    public void Visit(ConcreteComponentA element)
    {
        Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor1");
    }

    public void Visit(ConcreteComponentB element)
    {
        Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " + ConcreteVisitor1");
    }
}

class ConcreteVisitor2 : IVisitor
{
    public void Visit(ConcreteComponentA element)
    {
        Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor2");
    }

    public void Visit(ConcreteComponentB element)
    {
        Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " + ConcreteVisitor2");
    }
}