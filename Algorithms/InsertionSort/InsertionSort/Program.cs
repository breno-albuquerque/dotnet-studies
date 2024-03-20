// Insertion Sort
// Stable Algorithm
// Big-O notation: O(n^2)

// Demo
var arr = new int[] { 84, 21, 47, 96, 15 };

InsertionSort(arr, arr.Length);

foreach (var number in arr)
    Console.WriteLine(number);

void InsertionSort(int[] arr, int length)
{
    for (int i = 1; i < length; i++)
    {
        int temp = arr[i];
        int pos = i;

        while (pos > 0 && arr[pos - 1] > temp)
        {
            arr[pos] = arr[pos - 1];
            pos--;
        }
        
        arr[pos] = temp;
    }
}