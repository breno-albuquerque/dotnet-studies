namespace QueueLinkedImpl;

public sealed class LinkedQueue
{
    private Node? _front;

    private Node? _rear;

    private int _size;

    public LinkedQueue()
    {
        _front = null;
        _rear = null;
        _size = 0;
    }

    public bool IsEmpty => _size == 0;

    public void Enqueue(int element) // Add item to queue
    {
        var newNode = new Node(element, null);

        if (IsEmpty)
            _front = newNode;
        else
            _rear!.Next = newNode;
        
        _rear = newNode;
        _size++;
    }

    public int Dequeue() // Remove item from queue
    {
        if (IsEmpty)
        {
            Console.WriteLine("Queue is empty");
            return -1;
        }
        
        var item = _front!.Element;
        _front = _front!.Next;
        _size--;

        if (IsEmpty) _rear = null;
        
        return item;
    }

    public void Display()
    {
        var traverse = _front;

        while (traverse is not null)
        {
            Console.Write(traverse.Element + " --> ");
            traverse = traverse.Next;
        }
    }

    public int? GetFront() => _front?.Element;
}