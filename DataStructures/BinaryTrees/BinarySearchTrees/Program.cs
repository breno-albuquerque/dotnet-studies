using BinarySearchTrees;

var binarySearchTree = new BinarySearchTree();

binarySearchTree.RecursiveInsert(binarySearchTree.Root, 4);
binarySearchTree.RecursiveInsert(binarySearchTree.Root, 8);
binarySearchTree.RecursiveInsert(binarySearchTree.Root, 11);
binarySearchTree.RecursiveInsert(binarySearchTree.Root, 5);
binarySearchTree.RecursiveInsert(binarySearchTree.Root, 9);
binarySearchTree.RecursiveInsert(binarySearchTree.Root,19);
binarySearchTree.RecursiveInsert(binarySearchTree.Root, 15);
binarySearchTree.RecursiveInsert(binarySearchTree.Root, 12);
binarySearchTree.RecursiveInsert(binarySearchTree.Root, 2);
binarySearchTree.RecursiveInsert(binarySearchTree.Root, 1);
binarySearchTree.RecursiveInsert(binarySearchTree.Root, 3);

Console.WriteLine("InOrder:");
binarySearchTree.InOrder(binarySearchTree.Root);
Console.WriteLine("\nPreOrder:");
binarySearchTree.PreOrder(binarySearchTree.Root);
Console.WriteLine("\nPostOrder:");
binarySearchTree.PostOrder(binarySearchTree.Root);

Console.WriteLine("\nSearch for 15");
Console.WriteLine(binarySearchTree.Search(binarySearchTree.Root, 15));
Console.WriteLine("Search for 100");
Console.WriteLine(binarySearchTree.Search(binarySearchTree.Root, 100));
