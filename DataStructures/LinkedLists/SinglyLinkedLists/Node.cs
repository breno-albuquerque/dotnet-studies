namespace SinglyLinkedLists;

public class Node
{
    public int Value { get; }

    public Node? Next {get; set; }

    public Node(int value)
    {
        Value = value;
    }
}