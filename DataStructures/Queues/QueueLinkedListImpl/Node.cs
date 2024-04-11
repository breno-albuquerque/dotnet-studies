namespace QueueLinkedImpl;

public sealed class Node
{
    public int Element { get; }

    public Node? Next { get; set; }

    public Node(int element, Node? next)
    {
        Element = element;
        Next = next;
    }
}