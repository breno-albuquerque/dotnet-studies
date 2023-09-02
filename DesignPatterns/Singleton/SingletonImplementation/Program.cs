// Demo
var db = SingletonDatabase.Instance;
Console.WriteLine(db.GetUserAge("User3"));

var db2 = SingletonDatabase.Instance;
Console.WriteLine(db2.GetUserAge("User1"));

public interface IDataBase
{
    int GetUserAge(string username);
}

public class SingletonDatabase : IDataBase
{
    private readonly Dictionary<string, int> _users;
    
    private SingletonDatabase()
    {
        Console.WriteLine("Inicializando SingletonDatabese");
        
        _users = new Dictionary<string, int>
        {
            { "User1", 20 },
            { "User2", 30 },
            { "User3", 18 },
        };
    }

    // Inicializa apenas uma instância
    // O Lazy permite que seja inicializado a instâncio de SingletonDatabase apenas quando acessarem a prop Instance
    private static Lazy<SingletonDatabase> _instance = new(() => new SingletonDatabase());
    
    // Prop Instance que expõe a única instância de SingletonDatabase
    public static SingletonDatabase Instance => _instance.Value;

    public int GetUserAge(string username)
    {
        return _users[username];
    }
}