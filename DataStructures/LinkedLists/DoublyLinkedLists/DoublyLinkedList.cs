namespace DoublyLinkedLists;

public class DoublyLinkedList
{
    public Node? Head { get; private set; }

    public Node? Tail { get; private set; }

    public int Length { get; private set; }

    public bool IsEmpty => Length == 0;

    public DoublyLinkedList()
    {
        Head = null;
        Tail = null;
        Length = 0;
    }
    
    public void AddLast(int element) // Add element at the end
    {
        var newNode = new Node(element, null, null);
        
        if (IsEmpty)
            Head = newNode;
        else
        {
            Tail!.Next = newNode;
            newNode.Prev = Tail;
        }

        Tail = newNode;
        Length++;
    }
    
    public void AddFirst(int element) // Add element at the beginning
    {
        var newNode = new Node(element, null, null);
        
        if (IsEmpty)
            Tail = newNode;
        else
        {
            Head!.Prev = newNode;
            newNode.Next = Head;
        }

        Head = newNode;
        Length++;
    }

    public void DisplayForward() // Print all elements moving towards Tail
    {
        var traverse = Head;
        Console.Write("Forward: ");

        while (traverse is not null)
        {
            Console.Write(traverse.Element + " --> ");
            traverse = traverse.Next;
        }
        
        Console.WriteLine();
    }
    
    public void DisplayBackwards() // Print all elements moving towards Head
    {
        var traverse = Tail;
        Console.Write("Backwards: ");
        
        while (traverse is not null)
        {
            Console.Write(traverse.Element + " --> ");
            traverse = traverse.Prev;
        }
        
        Console.WriteLine();
    }
}