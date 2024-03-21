// Bubble Sort
// Stable Algorithm
// Big-O notation: O(n^2)

// Demo
var arr = new int[] { 84, 21, 47, 96, 15 };

BubbleSort(arr, arr.Length);

foreach (var number in arr)
    Console.WriteLine(number);

void BubbleSort(int[] arr, int length)
{
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
        }
    }
}