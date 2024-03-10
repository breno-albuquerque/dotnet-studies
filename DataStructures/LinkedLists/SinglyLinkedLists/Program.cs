using SinglyLinkedLists;

var numbers = new [] {2, 4, 3, 1, 8, 15, 12};

var created = Create(numbers);
Print(created);

var deleted = Delete(Create(numbers), 3);
Print(deleted);

var sorted = Sort(numbers);
Print(sorted);

// Create
Node Create(int[] array)
{
    Node nodes = null!;
    for (int i = 0; i < array.Length; i++)
    {
        var curr = new Node(array[i]);

        curr.Next = nodes;
        nodes = curr;
    }

    return nodes;
}

// Insert
Node Insert(Node nodes)
{
    var newNode = new Node(5);
    newNode.Next = nodes;
    nodes = newNode;

    return nodes;
}

// Delete
Node Delete(Node nodes, int value)
{
    var finder = nodes;
    
    while (finder.Next != null)
    {
        if (finder.Next.Value == value)
        {
            finder.Next = finder.Next.Next;
            break;
        }

        finder = finder.Next;
    }

    return nodes;
}

// Sort while creating
Node Sort(int[] array)
{
    Node sortedNodes = null;

    for (int i = 0; i < array.Length; i++)
    {
        var node = new Node(array[i]);
        
        if (sortedNodes == null)
        {
            sortedNodes = node;
            continue;
        }

        if (sortedNodes.Value > node.Value)
        {
            node.Next = sortedNodes;
            sortedNodes = node;
            continue;
        }

        if (sortedNodes.Next == null)
        {
            sortedNodes.Next = node;
            continue;
        }

        Node traverse = sortedNodes;
        while (traverse.Next != null)
        {
            if (traverse.Next.Value > node.Value)
            {
                node.Next = traverse.Next;
                traverse.Next = node;
                break;
            }

            traverse = traverse.Next;

            if (traverse.Next == null)
            {
                traverse.Next = node;
                break;
            }
        }
    }

    return sortedNodes;
}

// Print
void Print(Node nodes)
{
    Node printer = nodes!;
    while (printer != null)
    {
        Console.WriteLine(printer.Value);
        printer = printer.Next;
    }
    
    Console.WriteLine("-----------------");
}

