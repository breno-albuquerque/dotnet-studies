using System.Dynamic;
using System.Reflection;

// Demo
dynamic myDict = new MyDictionary();

myDict.FirstValue = "First Value";
myDict.SecondValue = "Second Value";

Console.WriteLine($"First Value: {myDict.FirstValue}");
Console.WriteLine($"Second Value: {myDict.SecondValue}");

myDict.A = "old";
myDict.B = "old";
myDict.C = "old";
myDict.D = "old";

Console.WriteLine($"A: {myDict.A}");
Console.WriteLine($"B: {myDict.B}");
Console.WriteLine($"C: {myDict.C}");
Console.WriteLine($"D: {myDict.D}");

myDict.ReplaceAllValues("old", "new");

Console.WriteLine($"A: {myDict.A}");
Console.WriteLine($"B: {myDict.B}");
Console.WriteLine($"C: {myDict.C}");
Console.WriteLine($"D: {myDict.D}");

public class MyDictionary : DynamicObject
{
    private readonly Dictionary<string, string> _root = new();

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        try
        {
            result = _root[binder.Name];
            return true;
        }
        catch
        {
            throw new ArgumentOutOfRangeException($"Key {binder.Name} is not present in the dictionary");
        }
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        if (value is not string valueStr)
            throw new InvalidOperationException("Only strings values a valid for this dictionary");

        _root[binder.Name] = valueStr;
        return true;
    }

    private void ReplaceAllValues(string oldValue, string newValue)
    {
        for (int i = 0; i < _root.Count; i += 1)
        {
            if (_root.ElementAt(i).Value == oldValue)
            {
                var key = _root.ElementAt(i).Key;
                _root[key] = newValue;
            }
        }
    }
    
    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
    {
        Console.WriteLine($"Invoking member: {binder.Name}");

        var method = GetType().GetMethod(binder.Name, BindingFlags.NonPublic | BindingFlags.Instance)!;
        result = method.Invoke(this, args);
        return true;
    }
}