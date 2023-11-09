using System.Dynamic;
using System.Text;

// Demo
var acc = new Account();
dynamic accountLoggerProxy = new Log<Account>(acc);

Console.WriteLine($"Acc balance: {acc.Balance}");

accountLoggerProxy.Deposit(5000);

Console.WriteLine($"Acc balance: {acc.Balance}");

accountLoggerProxy.Withdraw(2500);

Console.WriteLine($"Acc balance: {acc.Balance}");

public class Account 
{
    public int Balance { get; private set; }

    public void Deposit(int amount)
    {
        Balance += amount;
    }

    public bool Withdraw(int amount)
    {
        if (Balance - amount < 0)
            return false;

        Balance -= amount;
        
        return true;
    }
}

// Dynamic Log Proxy
public class Log<T> : DynamicObject
{
    private readonly T _subject;
    
    public Log(T subject)
    {
        _subject = subject;
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
    {
        try
        {
            var sb = new StringBuilder();

            sb.Append($"Invoking method: {binder.Name}. With args: ");

            foreach (var arg in args)
            {
                sb.Append($"{arg}, ");
            }

            result = _subject!.GetType().GetMethod(binder.Name)?.Invoke(_subject, args);
            
            Console.WriteLine(sb);
            return true;
        }
        catch
        {
            Console.WriteLine($"Fail trying to invoke method {binder.Name}");
            return base.TryInvokeMember(binder, args, out result);
        }
    }
}




