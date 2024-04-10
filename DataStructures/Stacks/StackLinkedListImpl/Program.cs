using StackLinkedListImpl;


// --------------------------------

var stack1 = new StackLinked();
stack1.Push(10);
stack1.Push(20);
stack1.Push(30);
stack1.Push(40);
    
Console.WriteLine("Stack 1: ");
stack1.Display();

stack1.Pop();
Console.WriteLine("Pop Stack 1");
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

stack1.Push(100);
Console.WriteLine("Push 100 to Stack 1: ");
stack1.Display();

stack1.Push(150);
Console.WriteLine("Push 150 to Stack 1: ");
stack1.Display();

Console.WriteLine("Stack 1. Getting Peek: " + stack1.Peek());

stack1.Pop();
Console.WriteLine("Pop Stack 1: ");
stack1.Display();

Console.WriteLine();
// --------------------------------