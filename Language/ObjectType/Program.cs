using ObjectType.RawTypes;
using ObjectType.TypesWithOverride;

Console.WriteLine("--------------------------------------- Testing with no override ---------------------------------------");

//  Built-in struct type
int number = 10;
var numberA = number.GetType();
var numberB = number.Equals(10);
var numberC = number.GetHashCode();
var numberD = number.ToString();
Print("Built-in struct type object inherited methods", numberA, numberB, numberC, numberD);

//  Struct Type
CoordsStruct coordsStruct = new(0, 0);
var coordsStructA = coordsStruct.GetType();
var coordsStructB = coordsStruct.Equals(new CoordsStruct(0, 0));
var coordsStructC = coordsStruct.GetHashCode();
var coordsStructD = coordsStruct.ToString();
Print("Struct type object inherited methods", coordsStructA, coordsStructB, coordsStructC, coordsStructD);

// Built-in reference type
string hello = "Hello World!";
var helloA = hello.GetType();
var helloB = hello.Equals("Hello World!");
var helloC = hello.GetHashCode();
var helloD = hello.ToString();
Print("Built-in reference type object inherited methods", helloA, helloB, helloC, helloD);

// Reference Type
CoordsClass coordsClass = new(0, 0);
var coordsClassA = coordsClass.GetType();
var coordsClassB = coordsClass.Equals(new CoordsClass(0, 0));
var coordsClassC = coordsClass.GetHashCode();
var coordsClassD = coordsClass.ToString();
Print("Reference type object inherited methods", coordsClassA, coordsClassB, coordsClassC, coordsClassD);

Console.WriteLine("--------------------------------------- Testing with OVERRIDE ---------------------------------------");

//  class
CoordsClassOverride coordsClassOverride = new(0, 0);
var coordsClassOverrideB = coordsClassOverride.Equals(new CoordsClassOverride(0, 0));
Print("Class Override", null, coordsClassOverrideB, null, null);

// struct
CoordsStructOverride coordsStructOverride = new(0, 0);
var coordsStructOverrideB = coordsStructOverride.Equals(new CoordsStructOverride(0, 0));
Print("Struct Override", null, coordsStructOverrideB, null, null);

static void Print(string scenario, object? a, object? b, object? c, object? d)
{
    Console.WriteLine($"----------------------- {scenario} -----------------------");

    if (a is not null)
        Console.WriteLine($"GetType: {a}");
    if (b is not null)
        Console.WriteLine($"Equals: {b}");
    if (c is not null)
        Console.WriteLine($"GetHashCode: {c}");
    if (d is not null)
        Console.WriteLine($"ToString: {d}");
}

