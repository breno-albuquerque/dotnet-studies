using DoublyLinkedLists;

var numbers = new [] {2, 4, 3, 1, 8, 15, 12};

Print(Create(numbers));
Print(Delete(Create(numbers), 1));

// Create
Node Create(int[] array)
{
    Node nodes = null;

    for (int i = 0; i < array.Length; i++)
    {
        var node = new Node(numbers[i]);
        
        if (nodes == null)
        {
            nodes = node;
            continue;
        }

        node.Next = nodes;
        node.Next.Prev = node;
        nodes = node;
    }
    
    return nodes;
}

// Delete
Node Delete(Node node, int value)
{
    var iterator = node;
    
    while (iterator != null)
    {
        if (iterator.Value == value)
        {
            if (iterator.Prev == null)
            {
                iterator = iterator.Next;
                iterator.Prev = null;
                break;
            }

            if (iterator.Next == null)
            {
                iterator.Prev.Next = null;
                break;
            }

            iterator.Prev.Next = iterator.Next;
            iterator.Next.Prev = iterator.Prev;
            break;
        }

        iterator = iterator.Next;
    }

    return node;
}

// Print
void Print(Node nodes)
{
    Node printer = nodes!;
    
    Console.WriteLine("Forward -----------------");

    do
    {
        Console.WriteLine(printer.Value);

        printer = printer.Next;

    } while (printer.Next != null);
    Console.WriteLine(printer.Value);
    
    
    Console.WriteLine("Backward -----------------");
    
    do
    {
        Console.WriteLine(printer.Value);

        printer = printer.Prev;

    } while (printer.Prev != null);
    Console.WriteLine(printer.Value);
}

