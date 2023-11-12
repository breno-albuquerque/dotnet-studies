// Demo
var game = new Game();

var goblin = new Creature(game, "Goblin", 3, 3);
Console.WriteLine(goblin);

using (new DoubleAttackModifier(game, goblin))
{
    Console.WriteLine("Goblin Attack: " + goblin.Attack);
}

Console.WriteLine("Goblin Attack: " + goblin.Attack);

public class Game
{
    // Event
    public event EventHandler<Query> Queries;

    // Raise Event
    public void PerformQuery(object sender, Query query)
    {
        Queries?.Invoke(sender, query);
    }
}

// Class that represents Event Args
public class Query : EventArgs
{
    public string CreatureName;
    public Argument WhatToQuery;
    public int Value;
    
    public enum Argument
    {
        Attack,
        Defense
    }

    public Query(string creatureName, Argument whatToQuery, int value)
    {
        CreatureName = creatureName;
        WhatToQuery = whatToQuery;
        Value = value;
    }
}


public class Creature
{
    private Game game;
    public string Name;
    private int attack, defense;

    public Creature(Game game, string name, int attack, int defense)
    {
        this.game = game;
        Name = name;
        this.attack = attack;
        this.defense = defense;
    }

    public int Attack
    {
        get
        {
            var query = new Query(Name, Query.Argument.Attack, attack);
            game.PerformQuery(this, query);
            return query.Value;
        }
    }
    
    public int Defense
    {
        get
        {
            var query = new Query(Name, Query.Argument.Defense, defense);
            game.PerformQuery(this, query);
            return query.Value;
        }
    }
}

public abstract class CreatureModifier : IDisposable
{
    protected Game game;

    protected Creature creature;

    protected CreatureModifier(Game game, Creature creature)
    {
        this.game = game;
        this.creature = creature;
        game.Queries += Handle; // Subscribe
    }
    
    protected abstract void Handle(object sender, Query query);
    
    public void Dispose()
    {
        game.Queries -= Handle;
    }
}

public class DoubleAttackModifier : CreatureModifier
{
    public DoubleAttackModifier(Game game, Creature creature) : base(game, creature)
    {
    }

    protected override void Handle(object sender, Query query)
    {
        if (query.CreatureName == creature.Name && query.WhatToQuery == Query.Argument.Attack)
            query.Value *= 2;
    }
}

