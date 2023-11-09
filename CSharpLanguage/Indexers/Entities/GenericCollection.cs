namespace Indexers.Entities;

public class GenericCollection<T>
    where T : class
{
    private readonly T[] _arr1 = new T[100];

    public T this[int i]
    {
        get => _arr1[i];
        set => _arr1[i] = value;
    }

    private readonly T[] _arr2 = new T[100];
    private int _lastIndex = 0;

    public T this[T i]
    {
        get
        {
            foreach (var item in _arr2)
            {
                if (item == i)
                    return item;
            }

            return default;
        }
        set
        {
            for (var j = 0; j < _lastIndex; j++)
            {
                if (_arr2[j] == i)
                {
                    _arr2[j] = value;
                    return;
                }
            }

            _arr2[_lastIndex] = value;
            _lastIndex += 1;
        }
    }

    public int GetArr2Index(string item)
    {
        for (var i = 0; i < _lastIndex; i += 1)
        {
            if (_arr2[i] == item)
                return i;
        }

        throw new ArgumentOutOfRangeException();
    }
}