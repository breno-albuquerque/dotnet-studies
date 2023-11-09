namespace Indexers.Contracts;

public interface IHourOfDay
{
    string this[int i]
    {
        get;
    }

    int GetHourIndex(string hour);
}