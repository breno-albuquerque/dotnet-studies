
public class Car
{
    private void Lock()
    {
        
    }

    public void Test()
    {
        var car = new Car();
        car.Lock();
    }
}

// public class Foo 
// {
//     private Foo() 
//     {
//
//     }
//
//     private async Task<Foo> InitAsync()
//     {
//         await Task.Delay(1000); // lógica assíncrona
//         return this;
//     }
//
//     public static Task<Foo> CreateAsync()
//     {
//         var result = new Foo();
//         return result.InitAsync();
//     }
// }