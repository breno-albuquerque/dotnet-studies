namespace DoublyLinkedLists;

public class Node
{
    public int Value { get; }

    public Node? Prev { get; set; }
    
    public Node? Next {get; set; }

    public Node(int value)
    {
        Value = value;
    }
}