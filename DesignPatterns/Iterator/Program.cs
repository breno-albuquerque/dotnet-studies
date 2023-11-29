// Demo

// Binary Tree Iterator Example
//   1
//  / \
// 2   3
// Expected Order of this iterator: 2, 1, 3

var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));
var tree = new BinaryTree<int>(root);

Console.WriteLine(string.Join(",", tree.InOrder.Select(x => x.Value)));

public class BinaryTree<T>
{
    private Node<T> _root;

    public BinaryTree(Node<T> root)
    {
        _root = root;
    }

    public IEnumerable<Node<T>> InOrder
    {
        get
        {
            IEnumerable<Node<T>> Traverse(Node<T> current)
            {
                if (current.Left is not null)
                    foreach (var left in Traverse(current.Left))
                        yield return left;

                yield return current;

                if (current.Right is not null)
                    foreach (var right in Traverse(current.Right))
                        yield return right;
            }

            foreach (var node in Traverse(_root))
                yield return node;
        }
    }
}

// Bynary Tree
public class Node<T>
{
    public T Value { get; set; }

    public Node<T>? Left { get; set; }
    public Node<T>? Right { get; set; }
    public Node<T>? Parent { get; set; }

    public Node(T value)
    {
        Value = value;
    }

    public Node(T value, Node<T> left, Node<T> right)
    {
        Value = value;
        Left = left;
        Right = right;

        Left.Parent = right.Parent = this;
    }
}