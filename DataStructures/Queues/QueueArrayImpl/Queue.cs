namespace QueueArrayImpl;

public sealed class Queue // Using circular arrays
{
    private int[] _items;

    private int _front;

    private int _rear;

    private int _size;

    private int _capacity;

    public Queue(int capacity)
    {
        _items = new int[capacity];
        _front = 0;
        _rear = 0;
        _size = 0;
        _capacity = capacity;
    }
    public bool IsEmpty => _size == 0;

    public bool IsFull => _size == _capacity;

    public void Enqueue(int item) // Add item to queue
    {
        if (IsFull)
        {
            Console.WriteLine("Queue is full");
            return;
        }
        
        _items[_rear] = item;
        _size++;

        if (_rear == _capacity - 1) _rear = 0; // circular array
        else _rear++;
    }

    public int Dequeue() // Remove item from queue
    {
        if (IsEmpty)
        {
            Console.WriteLine("Queue is empty");
            return -1;
        }

        var item = _items[_front];
        _items[_front] = default;
        _size--;

        if (_front == _capacity - 1) _front = 0; // circular array
        else _front++;
        
        return item;
    }

    public int GetFront() => _items[_front];
    
    public void Display()
    {
        for (int i = 0; i < _capacity; i++)
            Console.Write(_items[i] + " -- ");
    }
}