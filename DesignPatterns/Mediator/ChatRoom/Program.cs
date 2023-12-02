// Demo
var chatRoom = new ChatRoom();

var john = new Person("John");
var jane = new Person("Jane");

chatRoom.Join(john);
chatRoom.Join(jane);

john.Say("Hi");
jane.Say("Hello john");

var simon = new Person("Simon");
chatRoom.Join(simon);

simon.Say("Hi everyone!");
jane.PrivateMessage("Simon", "Glad you could join us!");

public class Person
{
    public string Name { get; set; }

    public IPeapleChatMediator ChatMediator { get; set; }
    
    private readonly List<string> _chatLog = new();

    public Person(string name)
    {
        Name = name;
    }

    public void Say(string message)
    {
        ChatMediator.Broadcast(Name, message);
    }

    public void PrivateMessage(string to, string message)
    {
        ChatMediator.Message(Name, to, message);
    }

    public void Receive(string sender, string message)
    {
        var fullMsg = $"{sender}: '{message}'";
        
        _chatLog.Add(fullMsg);
        
        Console.WriteLine($"[{Name}'s chat session] {fullMsg}");
    }
}

// Mediator interface
public interface IPeapleChatMediator
{
    void Join(Person p);
    
    void Broadcast(string source, string message);

    public void Message(string source, string destination, string message);
}

// Mediator
public class ChatRoom : IPeapleChatMediator
{
    private readonly List<Person> _people = new();

    public void Join(Person p)
    {
        Broadcast("room", $"{p.Name} joins the chat");
        
        p.ChatMediator = this;
        _people.Add(p);
    }

    public void Broadcast(string source, string message)
    {
        foreach (var p in _people)
            if (p.Name != source)
                p.Receive(source, message);
    }

    public void Message(string source, string destination, string message)
    {
        _people.FirstOrDefault(p => p.Name == destination)?.Receive(source, message);
    }
}