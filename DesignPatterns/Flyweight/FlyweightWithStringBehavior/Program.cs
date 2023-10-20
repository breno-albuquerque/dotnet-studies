var names = new List<string>() { "John", "Titor" };
// ---- TRACK REFERENCES: "John" (1); "Titor" (2)

// Demo user
var user1 = new User($"{names[0]} {names[1]}");
// ---- TRACK REFERENCES: "John Titor" (3)

var user2 = new User($"{names[0]} {names[1]}");
// ---- TRACK REFERENCES: "Titor John" (4)

// // Demo betterUser
var betterUser1 = new BetterUser($"{names[0]} {names[1]}");
// ---- TRACK REFERENCES: mantém 2

var betterUser2 = new BetterUser($"{names[0]} {names[1]}");
// ---- TRACK REFERENCES: mantém 2

Console.WriteLine("User 1: " + user1.FullName);
Console.WriteLine("User 2: " + user2.FullName);
Console.WriteLine("BetterUser 1: " + betterUser1.FullName);
Console.WriteLine("BetterUser 2: " + betterUser2.FullName);

public class User
{
    public string FullName { get; set; }
    
    public User(string fullName)
    {
        FullName = fullName;
    }
}

public class BetterUser
{
    private static List<string> Strings { get; } = new();
    
    public string FullName => string.Join(" ", _names.Select(i => Strings[i]));

    private readonly int[] _names;

    public BetterUser(string fullName)
    {
        int GetOrAdd(string s)
        {
            int idx = Strings.IndexOf(s);

            if (idx != -1) return idx;
            
            Strings.Add(s);
            return Strings.Count - 1;
        }

        _names = fullName.Split(' ').Select(GetOrAdd).ToArray();
    }
}





