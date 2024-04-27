namespace BinarySearchTrees;

public sealed class BinarySearchTree
{
    public Node? Root { get; set; }

    public BinarySearchTree()
    {
        Root = null;
    }
    
    public void RecursiveInsert(Node? root, int element) // Inserts element with Recursive Approach
    {
        if (Root is null)
        {
            Root =  new Node(element, null, null);;
            return;
        }
        
        if (element > root!.Element)
        {
            if (root.Right is null)
            {
                var newNode = new Node(element, null, null);
                root.Right = newNode;
                return;
            }

            RecursiveInsert(root.Right, element);
        }
        else if (element < root.Element)
        {
            if (root.Left is null)
            {
                var newNode = new Node(element, null, null);
                root.Left = newNode;
                return;
            }
                
            RecursiveInsert(root.Left, element);
        }
    }
    
    public void IterativeInsert(int element) // Inserts element with Iterative Approach
    {
        var newNode = new Node(element, null, null);

        if (Root is null)
        {
            Root = newNode;
            return;
        }

        var traverse = Root;
        var temp = traverse;

        while (traverse is not null)
        {
            temp = traverse;

            if (element > traverse.Element)
                traverse = traverse.Right;
            else if (element < traverse.Element)
                traverse = traverse.Left;
        }

        if (element > temp.Element)
            temp.Right = newNode;
        else if (element < temp.Element)
            temp.Left = newNode;
    }

    public int Search(Node? root, int? element) // Searches for element using Recursive Approach 
    {
        if (root is null)
            return -1;

        if (root.Element == element)
            return root.Element;

        if (element > root.Element)
            return Search(root.Right, element);
        
        return  Search(root.Left, element);
    }
    
    public void InOrder(Node? root) // Traverses Tree using InOrder Traversal
    {
        if (root is not null)
        {
            InOrder(root.Left);
            Console.Write(root.Element + "  ");
            InOrder(root.Right);
        }
    }

    public void PreOrder(Node? root) // Traverses Tree using PreOrder Traversal
    {
        if (root is not null)
        {
            Console.Write(root.Element + "  ");
            InOrder(root.Left);
            InOrder(root.Right);
        }
    }
    
    public void PostOrder(Node? root) // Traverses Tree using PostOrder Traversal
    {
        if (root is not null)
        {
            InOrder(root.Left);
            InOrder(root.Right);
            Console.Write(root.Element + "  ");
        }
    }
}