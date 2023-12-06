// Demo
var acc = new BankAccount(0);
var history = new BankAccountHistory(acc);

acc.Deposit(100);
history.Save();

acc.Deposit(50);
history.Save();

acc.Deposit(30);
history.Save();

history.Undo();
history.Undo();
history.Redo();

// Memento
public class Memento 
{
    public int Balance { get; } // Somente get para não expor o estado.

    public Memento(int balance)
    {
        Balance = balance;
    }
}

// Originator
public class BankAccount
{
    private int _balance;

    public BankAccount(int balance)
    {
        _balance = balance;
    }

    public void Deposit(int amount)
    {
        _balance += amount;
    }

    public void Restore(Memento memento)
    {
        _balance = memento.Balance;  
    }

    public Memento Save()
    {
        return new Memento(_balance);
    }
}

// Caretaker
public class BankAccountHistory
{
    private BankAccount _bankAccount;
    
    private List<Memento> _history;

    private int _current;

    public BankAccountHistory(BankAccount bankAccount)
    {
        _bankAccount = bankAccount;
        _history = new();
        _current = -1;
    }

    public void Save()
    {
        var memento = _bankAccount.Save();
        Console.WriteLine($"Saving account history. Balance: {memento.Balance}");

        _current++;
        _history.Add(memento);
    }

    public void Undo()
    {
        if (_current <= 0) return;
        
        Console.WriteLine($"Initiating undo. Balance: {_history.ElementAt(_current).Balance}");
        
        var memento = _history.ElementAt(--_current);
        
        Console.WriteLine($"Finishing undo. Balance: {_history.ElementAt(_current).Balance}");
        
        _bankAccount.Restore(memento);
    }

    public void Redo()
    {
        if (_history.Count - 1 <= _current) return;
        
        Console.WriteLine($"Initiating redo. Balance: {_history.ElementAt(_current).Balance}");
        
        var memento = _history.ElementAt(++_current);
        
        Console.WriteLine($"Finishing redo. Balance: {_history.ElementAt(_current).Balance}");
        
        _bankAccount.Restore(memento);
    }
}