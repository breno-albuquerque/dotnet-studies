using Indexers.Entities;

var collection = new GenericCollection<string>();

collection[0] = "arr1_test";
collection[1] = "arr1_test2";

Console.WriteLine($"{collection[0]}, {collection[1]}");

collection["arr2_test"] = "arr2_test";
collection["arr2_test2"] = "arr2_test2";
collection["arr2_test2"] = "changed";

Console.WriteLine("Index: " + collection.GetArr2Index("changed"));
Console.WriteLine($"{collection["arr2_test"]}, {collection["changed"]}");

var hourOfDay = new HourOfDay();

Console.WriteLine(hourOfDay[23]);
Console.WriteLine(hourOfDay.GetHourIndex("11:00pm"));