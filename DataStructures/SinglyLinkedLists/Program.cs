var numbers = new [] {2, 4, 3, 1, 8, 15, 12};

// Create a Linked List
Node nodes = null!;
for (int i = 0; i < numbers.Length; i++)
{
    var curr = new Node(numbers[i]);

    curr.Next = nodes;
    nodes = curr;
}

// Insertion
var newNode = new Node(5);
newNode.Next = nodes;
nodes = newNode;

// Deletion
var finder = nodes;
while (finder.Next != null)
{
    if (finder.Next.Value == 3)
    {
        finder.Next = finder.Next.Next;
        break;
    }

    finder = finder.Next;
}

// Traverse and print
Node printer = nodes!;
while (printer != null)
{
    Console.WriteLine(printer.Value);
    printer = printer.Next;
}

public class Node 
{
    public int Value { get; }

    public Node? Next {get; set; }

    public Node(int value)
    {
        Value = value;
    }
}