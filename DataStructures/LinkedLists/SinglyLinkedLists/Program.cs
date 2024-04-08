using SinglyLinkedLists;

var numbers = new [] {2, 4, 3, 1, 8, 15, 12};

// --------------------------------

var list1 = new LinkedList();
foreach (var number in numbers)
    list1.AddLast(number);

Console.WriteLine("List 1 - Length: " + list1.Length);
list1.Display();

Console.WriteLine();
// --------------------------------

var list2 = new LinkedList();
foreach (var number in numbers)
    list2.AddFirst(number);

Console.WriteLine("List 2 - Length: " + list2.Length);
list2.Display();

Console.WriteLine();
// --------------------------------

var list3 = new LinkedList();
foreach (var number in numbers)
    list3.AddLast(number);

Console.WriteLine("List 3 - Length: " + list3.Length);
list3.Display();

list3.AddAt(100, 0);
Console.WriteLine("Added 100 at position 0. List 3 - Length: " + list3.Length);
list3.Display();

list3.AddAt(200, 5);
Console.WriteLine("Added 200 at position 5. List 3 - Length: " + list3.Length);
list3.Display();

Console.WriteLine();
// --------------------------------

var list4 = new LinkedList();

Console.WriteLine("List 4 - Length: " + list4.Length);

list4.AddAt(100, 0);
Console.WriteLine("Added 100 at position 0. List 4 - Length: " + list4.Length);
list4.Display();

list4.AddAt(200, 0);
Console.WriteLine("Added 200 at position 0. List 4 - Length: " + list4.Length);
list4.Display();
    
list4.AddAt(300, 2);
Console.WriteLine("Added 300 at position 2. List 4 - Length: " + list4.Length);
list4.Display();

Console.WriteLine();
// --------------------------------

var list5 = new LinkedList();
list5.AddFirst(200);
list5.AddFirst(100);

Console.WriteLine("List 5 - Length: " + list5.Length);
list5.Display();

list5.DeleteFirst();
Console.WriteLine("Deleted first element. List 5 - Length: " + list5.Length);
list5.Display();

list5.DeleteFirst();
Console.WriteLine("Deleted first element. List 5 - Length: " + list5.Length);
list5.Display();

Console.WriteLine();
// --------------------------------

var list6 = new LinkedList();
list6.AddFirst(300);
list6.AddFirst(200);
list6.AddFirst(100);

Console.WriteLine("List 6 - Length: " + list6.Length);
list6.Display();

list6.DeleteLast();
Console.WriteLine("Deleted last element. List 6 - Length: " + list6.Length);
list6.Display();

list6.DeleteLast();
Console.WriteLine("Deleted last element. List 6 - Length: " + list6.Length);
list6.Display();

list6.DeleteLast();
Console.WriteLine("Deleted last element. List 6 - Length: " + list6.Length);
list6.Display();

Console.WriteLine();
// --------------------------------

var list7 = new LinkedList();
list7.AddFirst(400);
list7.AddFirst(300);
list7.AddFirst(200);
list7.AddFirst(100);

Console.WriteLine("List 7 - Length: " + list7.Length);
list7.Display();

list7.DeleteAt(3);
Console.WriteLine("Deleted element at 3. List 7 - Length: " + list7.Length);
list7.Display();

list7.DeleteAt(1);
Console.WriteLine("Deleted element at 1. List 7 - Length: " + list7.Length);
list7.Display();

list7.DeleteAt(0);
Console.WriteLine("Deleted element at 0. List 7 - Length: " + list7.Length);
list7.Display();

list7.DeleteAt(0);
Console.WriteLine("Deleted element at 0. List 7 - Length: " + list7.Length);
list7.Display();

Console.WriteLine();
// --------------------------------

var list8 = new LinkedList();

foreach (var number in numbers)
{
    list8.AddSorted(number);
    Console.WriteLine($"List 8: Added number {number} in sorted order. Length: {list8.Length}");
    list8.Display();
}