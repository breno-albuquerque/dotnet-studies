// Linear Search
// Big-O notation: O(n)

// Demo
var arr = new int[] { 84, 21, 47, 96, 15 };

var forResult = ForLinearSearch(arr, 5, 96);
var whileResult = WhileLinearSearch(arr, 5, 96);

Console.WriteLine(forResult);
Console.WriteLine(whileResult);


int ForLinearSearch(int[] arr, int length, int element)
{
    for (int index = 0; index < length; index++)
    {
        if (arr[index] == element)
            return index;
    }

    return -1;
}

int WhileLinearSearch(int[] arr, int length, int element)
{
    int index = 0;
    
    while (index < length) {
        if (arr[index] == element)
            return index;
        
        index++;
    }

    return -1;
}
