var equipment = new EquipmentBuilder()
    .Industry("Mining")
    .EquipmentType("Excavator")
    .EquipmentMake("JCB")
    .EquipmentModel("3Tx")
    .PurchaseYear("2020")
    .Build();

Console.WriteLine(equipment);

public class Equipment
{
    public string Type { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Industry { get; set; }
    
    public string PurchaseYear { get; set; }
    
    public override string ToString()
    {
        return $"{nameof(Type)}: {Type}, {nameof(Make)}: {Make}, {nameof(Model)}: {Model}, {nameof(Industry)}: {Industry}";
    }
}

public abstract class GenericFunctionalBuilder<TSubject, TSelf>
    where TSubject : new()
    where TSelf : GenericFunctionalBuilder<TSubject, TSelf>
{
    /// <summary>
    ///  To hold a list fluent actions.
    /// </summary>
    private readonly List<Func<TSubject, TSubject>> actions 
        = new List<Func<TSubject, TSubject>>();

    /// <summary>
    /// Helps in adding functions to a list of action.
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public TSelf Do(Action<TSubject> action)
    {
        AddActions(action);
        return (TSelf)this;
    }
	
    /// <summary>
    /// Adds all fuctions to a list
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    private TSelf AddActions(Action<TSubject> action)
    {
        actions.Add(p => {
            action(p);
            return p;
        });
        return (TSelf)this;
    }

    /// <summary>
    /// Builds Subject In Very Fluent Way
    /// </summary>
    /// <returns></returns>
    public TSubject Build()
    {
        return actions.Aggregate(new TSubject(), (p, f) => f(p));
    }
}

/// <summary>
/// One can't modify or inherit but one can extend anytime.
/// </summary>
public sealed class EquipmentBuilder 
    : GenericFunctionalBuilder<Equipment, EquipmentBuilder>
{
    /// <summary>
    /// Industry 
    /// </summary>
    /// <param name="industry"></param>
    /// <returns></returns>
    public EquipmentBuilder Industry(string industry)
    {
        return Do(e => e.Industry = industry);
    }

    /// <summary>
    /// Equipment Type
    /// </summary>
    /// <param name="equipmentType"></param>
    /// <returns></returns>
    public EquipmentBuilder EquipmentType(string equipmentType)
    {
        return Do(e => e.Type = equipmentType);
    }

    /// <summary>
    /// Equipment Make
    /// </summary>
    /// <param name="equipmentMake"></param>
    /// <returns></returns>
    public EquipmentBuilder EquipmentMake(string equipmentMake)
    {
        return Do(e => e.Make = equipmentMake);
    }

    /// <summary>
    /// Equipment Model
    /// </summary>
    /// <param name="equipmentModel"></param>
    /// <returns></returns>
    public EquipmentBuilder EquipmentModel(string equipmentModel)
    {
        return (Do(e => e.Model = equipmentModel));
    }
}

/// <summary>
/// Extended class with method Purchase Year method.
/// </summary>
public static class EquipmentBuilderExtensions
{
    public static EquipmentBuilder PurchaseYear(this EquipmentBuilder builder, 
        string purchaseYear)
    {
        return builder.Do(p => p.PurchaseYear = purchaseYear);
    }
}
