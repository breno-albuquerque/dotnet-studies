
// Demo
BaseClass bc = new BaseClass();
DerivedClass dc = new DerivedClass();
BaseClass bcdc = new DerivedClass();

bc.Method1();
bc.Method2();
// Output:  
// Base - Method1  
// Base - Method2  

dc.Method1();
dc.Method2();
// Output:  
// Derived - Method1  
// Derived - Method2  

// O modificador override permite que a classe "bcdc", mesmo sendo declarada como tipo "BaseClass",
// Tenha acesso ao método sobreescrito.
bcdc.Method1();
bcdc.Method2();
// Output:  
// Derived - Method1  
// Base - Method2  

class BaseClass
{
    public virtual void Method1()
    {
        Console.WriteLine("Base - Method1");
    }

    public virtual void Method2()
    {
        Console.WriteLine("Base - Method2");
    }
}

class DerivedClass : BaseClass
{
    public override void Method1()
    {
        Console.WriteLine("Derived - Method1");
    }

    // Caso não seja adicionado o modificador "new", o método se comportará como se "new" estivesse lá,
    // Porém terá um aviso para adicionar o "new" explicitando que o método base está sendo ocultado
    public new void Method2()
    {
        Console.WriteLine("Derived - Method2");
    }
}