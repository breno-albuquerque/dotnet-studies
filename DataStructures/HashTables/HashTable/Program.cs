using HashTable;

var hashTable = new HashTable<string, int>(20);

hashTable.TryAdd("Breno", 23);
hashTable.TryAdd("John", 30);
hashTable.TryAdd("Ana", 19);
hashTable.TryAdd("Bruce", 70);
hashTable.TryAdd("Mary", 30);

Console.WriteLine("Breno - " + hashTable.Get("Breno").Value);
Console.WriteLine("John - " + hashTable.Get("John").Value);
Console.WriteLine("Ana - " + hashTable.Get("Ana").Value);
Console.WriteLine("Bruce - " + hashTable.Get("Bruce").Value);
Console.WriteLine("Mary - " + hashTable.Get("Mary").Value);
