namespace SinglyLinkedLists;

public sealed class LinkedList // Treating as 0 indexed. First element -> position 0.
{
    public Node? Head { get; private set; }

    public Node? Tail { get; private set; }

    public int Length { get; private set; }

    public bool IsEmpty => Length == 0;

    public LinkedList()
    {
        Head = null;
        Tail = null;
        Length = 0;
    }

    public void AddLast(int element) // Add element at the end
    {
        var newNode = new Node(element, null);

        if (IsEmpty)
            Head = newNode;
        else
            Tail!.Next = newNode;

        Tail = newNode;
        Length += 1;
    }

    public void AddFirst(int element) // Add element at the beginning
    {
        var newNode = new Node(element, Head);

        if (IsEmpty)
            Tail = newNode;

        Head = newNode;
        Length += 1;
    }

    public void AddAt(int element, int position) // Add element at given position
    {
        if (position > Length || position < 0)
        {
            Console.WriteLine($"Can't insert element at given position: {position}");
            return;
        }

        if (position == 0) // If inserting at the begging
        {
            AddFirst(element);
            return;
        }

        if (position == Length) // If inserting at the end
        {
            AddLast(element);
            return;
        }

        Add(element, position);
    }

    public void AddSorted(int element) // Add element at sorted position
    {
        if (IsEmpty || element < Head!.Element)
        {
            AddFirst(element);
            return;
        }
        
        var newNode = new Node(element, null);

        var traverse = Head;

        while (traverse!.Next is not null && traverse.Next.Element < element)
            traverse = traverse.Next;

        newNode.Next = traverse.Next;
        traverse.Next = newNode;
    }

    public void DeleteFirst() // Deletes element at first position
    {
        if (IsEmpty)
        {
            Console.WriteLine("List is empty");
            return;
        }
        
        Head = Head!.Next;
        Length--;

        if (IsEmpty)
            Tail = null;
    }

    public void DeleteLast() // Deletes last at first position
    {
        if (IsEmpty)
        {
            Console.WriteLine("List is empty");
            return;
        }

        if (Length == 1) // Same as deleting first, since list has only one element 
        {
            DeleteFirst();
            return;
        }

        var traverse = Head;
        int count = 1;

        while (count < Length - 1)
        {
            traverse = traverse!.Next;
            count++;
        }

        traverse!.Next = null;
        Tail = traverse;
        Length--;
    }

    public void DeleteAt(int position) // Deletes at given position
    {
        if (position < 0 || position >= Length)
        {
            Console.WriteLine("Invalid position");
            return;
        }
        
        if (position == 0) // If deleting first
        {
            DeleteFirst();
            return;
        }

        if (position == Length - 1) // If deleting last
        {
            DeleteLast();
            return;
        }

        int count = 1;
        var traverse = Head;

        while (count < position)
        {
            traverse = traverse!.Next;
            count++;
        }

        traverse!.Next = traverse.Next!.Next;
        Length--;
    }

    public void Display() // Print all elements
    {
        var traverse = Head;
        
        while (traverse is not null)
        {
            Console.Write(traverse.Element + " --> ");
            traverse = traverse.Next;
        }
        
        Console.WriteLine();
    }
    
    private void Add(int element, int position) // Add at given position different that beginning and end
    {
        var newNode = new Node(element, null);
        
        int count = 0;
        var traverse = Head;

        while (count < position - 1)
        {
            traverse = traverse!.Next;
            count++;
        }

        newNode.Next = traverse!.Next;
        traverse.Next = newNode;

        Length++;
    }
}