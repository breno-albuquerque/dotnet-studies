using StackArrayImpl;

var numbers = new [] {2, 4, 3, 1};

// --------------------------------

var stack1 = new Stack(4);
foreach (var number in numbers)
    stack1.Push(number);
    
Console.WriteLine("Stack 1: ");
stack1.Display();

stack1.Pop();
Console.WriteLine("Pop Stack 1: ");
stack1.Display();
    
stack1.Pop();
Console.WriteLine("Pop Stack 1: ");
stack1.Display();

stack1.Pop();
Console.WriteLine("Pop Stack 1: ");
stack1.Display();

stack1.Pop();
Console.WriteLine("Pop Stack 1: ");
stack1.Display();

stack1.Push(10);
Console.WriteLine("Push 10 to Stack 1: ");
stack1.Display();

stack1.Push(15);
Console.WriteLine("Push 15 to Stack 1: ");
stack1.Display();

Console.WriteLine();
// --------------------------------

var stack2 = new Stack(4);
foreach (var number in numbers)
    stack2.Push(number);

Console.WriteLine("Stack 2 - Size: " + stack2.Size);
stack2.Display();

stack2.Push(10);
Console.WriteLine("Push 10 beyond stack boundaries. Stack - Size: " + stack2.Size);
stack2.Display();

Console.WriteLine("Stack 2. Getting Peek: " + stack2.Peek());
