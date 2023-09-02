// Demo
var task1 = Task.Factory.StartNew(() =>
{
    Console.WriteLine("Task 1: " + SingletonFoo.Instance.Id);
    Console.WriteLine("Task 1: " + SingletonFoo.Instance.Id);
});

var task2 = Task.Factory.StartNew(() =>
{
    Console.WriteLine("Task 2: " + SingletonFoo.Instance.Id);
    Console.WriteLine("Task 2: " + SingletonFoo.Instance.Id);
});

Task.WaitAll(task1, task2);

public class SingletonFoo
{
    private static readonly ThreadLocal<SingletonFoo> ThreadInstance = new(() => new SingletonFoo());

    public static SingletonFoo Instance => ThreadInstance.Value!;

    public int Id { get; }
    
    private SingletonFoo()
    {
        Id = Thread.CurrentThread.ManagedThreadId;
    }
}