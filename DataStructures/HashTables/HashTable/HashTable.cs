
namespace HashTable;

public sealed class HashTable<TKey, TValue>
{
    private KeyValuePair<TKey, TValue>?[] _items;

    private int _size;

    public HashTable(int n)
    {
        _items = new KeyValuePair<TKey, TValue>[n];
        _size = n;
    }

    public bool TryAdd(TKey key, TValue value)
    {
        var keyValuePair = new KeyValuePair<TKey, TValue>(key, value);
        
        var index = Hash(key);

        if (_items[index] != default)
            return false;
        
        _items[index] = keyValuePair;
        return true;
    }

    public KeyValuePair<TKey, TValue>? Get(TKey key)
    {
        var index = Hash(key);
        return _items[index];
    }
    
    private int Hash(TKey key)
    {
        int hash = 0;
    
        foreach (var element in key!.ToString()!)
            hash += element.GetHashCode();

        return hash % _size;
    }
}