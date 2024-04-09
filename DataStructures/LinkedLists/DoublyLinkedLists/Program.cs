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

var list3 = new DoublyLinkedList();
list3.AddFirst(300);
list3.AddFirst(200);
list3.AddFirst(100);

Console.WriteLine("List 3 - Length: " + list3.Length);
list3.DisplayForward();

list3.DeleteFirst();
Console.WriteLine("Deleted first element. List 3 - Length: " + list3.Length);
list3.DisplayForward();

list3.DeleteFirst();
Console.WriteLine("Deleted first element. List 3 - Length: " + list3.Length);
list3.DisplayForward();

list3.DeleteFirst();
Console.WriteLine("Deleted first element. List 3 - Length: " + list3.Length);
list3.DisplayForward();

Console.WriteLine();
// --------------------------------

var list4 = new DoublyLinkedList();
list4.AddFirst(300);
list4.AddFirst(200);
list4.AddFirst(100);

Console.WriteLine("List 4 - Length: " + list4.Length);
list4.DisplayForward();

list4.DeleteLast();
Console.WriteLine("Deleted last element. List 4 - Length: " + list4.Length);
list4.DisplayForward();

list4.DeleteLast();
Console.WriteLine("Deleted last element. List 4 - Length: " + list4.Length);
list4.DisplayForward();

list4.DeleteLast();
Console.WriteLine("Deleted last element. List 4 - Length: " + list4.Length);
list4.DisplayForward();

Console.WriteLine();
// --------------------------------
