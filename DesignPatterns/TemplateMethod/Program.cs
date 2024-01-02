// Demo
var chess = new Chess();

chess.Run();

public abstract class Game
{
    public void Run() // Template Method
    {
        Start();

        while (HasEnded) TakeTurn();
        
        Console.WriteLine("Game has ended");
    }

    protected abstract void Start();

    protected abstract void TakeTurn();
    
    protected abstract bool HasEnded { get; }

    protected virtual void StopGame() {  } // Hook example
}

public class Chess : Game
{
    public int Turn { get; set; }
    
    protected override void Start()
    {
        Console.WriteLine("Starting Chess Game");
    }

    protected override void TakeTurn()
    {
        Turn++;
        Console.WriteLine("Taking turn turn");
    }

    protected override bool HasEnded => Turn >= 10;
}