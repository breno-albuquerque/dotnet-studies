namespace BinarySearchTrees;

public class Node
{
    public int Element { get; }

    public Node? Left { get; set; }
    
    public Node? Right {get; set; }

    public Node(int element, Node? right, Node? left)
    {
        Element = element;
        Right = right;
        Left = left;
    }
}