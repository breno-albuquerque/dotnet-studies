// Demo 1
var goblin = new Creature("Goblin", 10, 10);
Console.WriteLine(goblin);

// Base Modifier
var goblinModifier = new CreatureModifier(goblin);

// Add modifiers
goblinModifier.Add(new DoubleAttackModifier(goblin));
goblinModifier.Add(new DoubleDefenseModifier(goblin));

// Apply all modifiers added
goblinModifier.Handle();
// output: "Name Goblin, Attack: 20, Defence: 20"

Console.WriteLine(goblin);

// Modifier Instance
    // _next -> DoubleAttack Instance
                // _next -> DoubleDefense Instance
                            // _next -> null

// Modifier.Handle() -> DoubleAttack.Handle() -> DoubleDefense.Handle();

// Demo 2
var dragon = new Creature("Dragon", 500, 500);

// Base Modifier
var dragonModifier = new CreatureModifier(dragon);

// Add modifiers
dragonModifier.Add(new DoubleAttackModifier(dragon));
dragonModifier.Add(new NoModifiers(dragon));
dragonModifier.Add(new DoubleDefenseModifier(dragon));

// Apply all modifiers added
dragonModifier.Handle();
// output: "Name Dragon, Attack: 1000, Defence: 500"

// Modifier Instance
    // _next -> DoubleAttack Instance
                    // _next -> NoModifiers Instance
                                    // _next -> DoubleDefenseModifier Instance

// Modifier.Handle() -> DoubleAttack.Handle() -> NoModifiers.Handle() -> A partir daqui não chama mais modifiers;

public class Creature
{
    public string Name { get; set; }

    public int Attack { get; set; }

    public int Defence { get; set; }

    public Creature(string name, int attack, int defence)
    {
        Name = name;
        Attack = attack;
        Defence = defence;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defence)}: {Defence}";
    }
}

public class CreatureModifier
{
    protected Creature _creature;

    protected CreatureModifier _next; // Chain (linked list)

    public CreatureModifier(Creature creature)
    {
        _creature = creature;
    }

    public void Add(CreatureModifier cm)
    {
        if (_next is not null) _next.Add(cm);
        else _next = cm;
    }
    
    public virtual void Handle() => _next?.Handle();
}

public class DoubleAttackModifier : CreatureModifier
{
    public DoubleAttackModifier(Creature creature) : base(creature)
    {
    }

    // Projeto CSharpLanguage\OverrideAndNew.csproj para detalhes do override
    public override void Handle()
    {
        Console.WriteLine($"Doubling {_creature.Name}'s attack.");
        _creature.Attack *= 2;
        base.Handle();
    }
}

public class DoubleDefenseModifier : CreatureModifier
{
    public DoubleDefenseModifier(Creature creature) : base(creature)
    {
    }
    
    // Projeto CSharpLanguage\OverrideAndNew.csproj para detalhes do override
    public override void Handle()
    {
        Console.WriteLine($"Doubling {_creature.Name}'s defense.");
        _creature.Defence *= 2;
        base.Handle();
    }
}

public class NoModifiers : CreatureModifier
{
    public NoModifiers(Creature creature) : base(creature)
    {
    }
    
    // Projeto CSharpLanguage\OverrideAndNew.csproj para detalhes do override
    public override void Handle()
    {
        Console.WriteLine("No modifiers beeing applied");
    }
}