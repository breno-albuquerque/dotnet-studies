namespace StackLinkedListImpl;

public sealed class StackLinked
{
    private Node? _top;

    private int _size;

    public StackLinked()
    {
        _top = null;
        _size = 0;
    }

    public bool IsEmpty => _size == 0;
    
    public void Push(int item) // Add into top
    {
        var newNode = new Node(item, null);
        
        if (IsEmpty)
        {
            _top = newNode;
            _size++;
            return;
        }

        newNode.Next = _top;
        _top = newNode;
        
        _size++;
    }

    public void Pop() // Remove from top
    {
        if (IsEmpty)
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        _top = _top!.Next;
        _size--;
    }

    public int Peek() // Get top item
    {
        if (IsEmpty)
        {
            Console.WriteLine("Stack is empty");
            return -1;
        }

        return _top!.Element;
    }

    public void Display() // Display all items
    {
        var traverse = _top;
        
        while (traverse is not null)
        {
            if (traverse.Next is not null)
                Console.Write(traverse.Element + " -- ");
            else 
                Console.Write(traverse.Element);

            traverse = traverse.Next;
        }
        
        Console.WriteLine();
    }
}