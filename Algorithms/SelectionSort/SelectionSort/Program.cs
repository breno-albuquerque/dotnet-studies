// Selection Sort
// Unstable Algorithm
// Big-O notation: O(n^2)

// Demo
var arr = new int[] { 84, 21, 47, 96, 15 };

SelectionSort(arr, arr.Length);

foreach (var number in arr)
    Console.WriteLine(number);

void SelectionSort(int[] arr, int length)
{
    for (int i = 0; i < length - 1; i++)
    {
        int pos = i;

        for (int j = i + 1; j < length; j++)
            if (arr[j] < arr[pos])
                pos = j;
        
        (arr[i], arr[pos]) = (arr[pos], arr[i]);
    }
}