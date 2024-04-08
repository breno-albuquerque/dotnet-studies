using DoublyLinkedLists;

var numbers = new [] {2, 4, 3, 1, 8, 15, 12};

// --------------------------------

var list1 = new DoublyLinkedList();
foreach (var number in numbers)
    list1.AddLast(number);

Console.WriteLine("List 1 - Length: " + list1.Length);
list1.DisplayForward();
list1.DisplayBackwards();

Console.WriteLine();
// --------------------------------

var list2 = new DoublyLinkedList();
foreach (var number in numbers)
    list2.AddFirst(number);

Console.WriteLine("List 2 - Length: " + list2.Length);
list2.DisplayForward();
list2.DisplayBackwards();

Console.WriteLine();
// --------------------------------
