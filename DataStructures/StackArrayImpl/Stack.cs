namespace StackArrayImpl;

public sealed class Stack
{
    private int[] _items;

    private int _top;

    public Stack(int size)
    {
        _items = new int[size];
        _top = 0;
    }
    
    public bool IsFull => _top == _items.Length;

    public bool IsEmpty => _top == 0;

    public int Size => _top;
    
    public void Push(int item) // Add into top
    {
        if (IsFull)
        {
            Console.WriteLine("Stack is full. Resizing...");
            Resize();
        }
            
        _items[_top] = item;
        _top++;
    }

    public void Pop() // Remove from top
    {
        if (IsEmpty)
        {
            Console.WriteLine("Stack is empty");
            return;
        }
        
        _items[_top - 1] = default;
        _top--;
    }

    public int Peek() // Get top item
    {
        if (IsEmpty)
        {
            Console.WriteLine("Stack is empty");
            return -1;
        }

        return _items[_top - 1];
    }

    public void Display() // Display all items
    {
        for (int i = 0; i < _top; i++)
        {
            if (i == _top - 1)
                Console.Write(_items[i]);
            else
                Console.Write(_items[i] + " -- ");
        }
        
        Console.WriteLine();
    }
    
    private void Resize() // Dynamic Array. Grow array size 2x
    {
        var newSize = _top * 2;
        int[] newArray = new int[newSize];

        Array.Copy(_items, newArray, _top);

        _items = newArray;
    }
}