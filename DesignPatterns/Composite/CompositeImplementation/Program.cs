// Demo
var sp = new SingleProduct(1);
var sp2 = new SingleProduct(1);
var cp = new CompositeProduct { Products = new List<Product> { sp, sp2 } };
var cp2 = new CompositeProduct { Products = new List<Product> { sp, sp2, cp }};

// 8
var cp3 = new CompositeProduct { Products = new List<Product> { sp, sp2, cp, cp2 }};

// 16
var cp4 = new CompositeProduct { Products = new List<Product> { sp, sp2, cp, cp2, cp3 }};

var result = cp4.GetPrice();
Console.WriteLine("Result: " + result);

// Only exposes one method to uniformly treat Product and Box
public abstract class Product
{
    public abstract int GetPrice();
}

public class SingleProduct : Product
{
    private readonly int _price;
    
    public SingleProduct(int price)
    {
        _price = price;
    }
    
    public override int GetPrice()
    {
        return _price;
    }
}

public class CompositeProduct : Product
{
    public List<Product> Products { get; set; } = new();

    public override int GetPrice()
    {
        var result = 0;

        foreach (var product in Products)
        {
            if (product is CompositeProduct compositeProduct)
                result += compositeProduct.GetPrice();
            else
                result += product.GetPrice();
        }

        return result;
    }
    
}