// Demo
var acc = new Account(1000);

var commands = new List<AccountCommand>()
{
    new(acc, AccountAction.Deposit, 500),
    new(acc, AccountAction.Withdraw, 1500),
    new(acc, AccountAction.Withdraw, 1000),
};

foreach(var command in commands)
    command.Execute();

foreach(var command in commands)
    command.Rollback();

// Composite Demo
var accFrom = new Account(1000);
var accTo = new Account(1000);

var transferCommand = new TransferCommand(accFrom, accTo, 2000);

transferCommand.Execute();

// Classe em que os commands realizarão as operações.
public class Account
{
    private int _balance;

    private const int Limit = -500;
    
    public Account(int balance)
    {
        _balance = balance;
    }


    public bool Deposit(int amount)
    {
        _balance += amount;
        Console.WriteLine($"Deposited {amount}. Balance is now {_balance}");

        return true;
    }

    public bool Withdraw(int amount)
    {
        if (_balance - amount < Limit)
        {
            Console.WriteLine($"Cannot withdraw {amount}. Balance still {_balance}");
            return false;
        }
        
        _balance -= amount;
        Console.WriteLine($"Withdrew {amount}. Balance is now {_balance}");
        return true;
    }

    public override string ToString()
    {
        return $"{nameof(_balance)}: {_balance}";
    }
}

// Command Interface
public interface ICommand
{
    void Execute();
    
    void Rollback();
}

// Command example
public class AccountCommand : ICommand
{
    private readonly Account _account;
    private readonly AccountAction _action;
    private readonly int _amount;

    public bool Succeeded;
    
    public AccountCommand(Account account, AccountAction action, int amount)
    {
        _account = account;
        _action = action;
        _amount = amount;
    }

    public void Execute()
    {
        if (_action == AccountAction.Deposit)
            Succeeded = _account.Deposit(_amount);
        
        if (_action == AccountAction.Withdraw)
            Succeeded= _account.Withdraw(_amount);
    }

    public void Rollback()
    {
        if (!Succeeded) return;
        
        if (_action == AccountAction.Deposit)
            Succeeded = _account.Withdraw(_amount);
        
        if (_action == AccountAction.Withdraw)
            Succeeded= _account.Deposit(_amount);
    }
}

// Composite command
public abstract class CompositeAccountCommand : List<AccountCommand>, ICommand
{
    public virtual void Execute()
    {
        ForEach(command => command.Execute());
    }

    public void Rollback()
    {
        foreach (var command in ((IEnumerable<AccountCommand>)this).Reverse())
        {
            command.Rollback();   
        }
    }
}

public class TransferCommand : CompositeAccountCommand
{
    public TransferCommand(Account from, Account to, int amount)
    {
        Add(new AccountCommand(from, AccountAction.Withdraw, amount));
        Add(new AccountCommand(to, AccountAction.Deposit, amount));
    }

    public override void Execute()
    {
        bool succeeded = true;
        
        foreach (var command in this)
        {
            if (succeeded)
            {
                command.Execute();
                succeeded = command.Succeeded;
            }
        }
    }
}

public enum AccountAction
{
    Deposit = 1,
    Withdraw = 2
}