// Demo
var ae = new AdditionExpression(new DoubleExpression(10), new DoubleExpression(14));

var et = new EvaluationTransformer();
Console.WriteLine(et.Transform(ae));

var pt = new PrintTransformer();
Console.WriteLine(pt.Transform(ae));

public abstract class Expression // Base Component 
{
    public abstract T Reduce<T>(ITransformer<T> transformer); // another approach to classic "accept", but with return type
}

public class DoubleExpression : Expression // Concrete Component
{
    public readonly double Value;

    public DoubleExpression(double value)
    {
        Value = value;
    }

    public override T Reduce<T>(ITransformer<T> transformer)
    {
        return transformer.Transform(this); // double dispatch
    }
}

public class AdditionExpression : Expression // Concrete Component
{
    public readonly Expression Left, Right;

    public AdditionExpression(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    public override T Reduce<T>(ITransformer<T> transformer)
    {
        return transformer.Transform(this); // double dispatch
    }
}

public interface ITransformer<T> // Visitor interface
{
    T Transform(DoubleExpression de);
    T Transform(AdditionExpression ae);
}

public class EvaluationTransformer : ITransformer<double> // Concrete Visitor
{
    public double Transform(DoubleExpression de)
    {
        return de.Value;
    }

    public double Transform(AdditionExpression ae)
    {
        return ae.Left.Reduce(this) + ae.Right.Reduce(this);
    }
}

public class PrintTransformer : ITransformer<string> // Concrete Visitor
{
    public string Transform(DoubleExpression de)
    {
        return de.Value.ToString();
    }

    public string Transform(AdditionExpression ae)
    {
        return $"{ae.Left.Reduce(this)} + {ae.Right.Reduce(this)}";
    }
}