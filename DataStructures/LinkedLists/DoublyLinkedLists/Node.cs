namespace DoublyLinkedLists;

public class Node
{
    public int Element { get; }

    public Node? Prev { get; set; }
    
    public Node? Next {get; set; }

    public Node(int element, Node? next, Node? prev)
    {
        Element = element;
        Next = next;
        Prev = prev;
    }
}