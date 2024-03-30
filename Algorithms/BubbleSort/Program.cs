// Bubble Sort
// Stable Algorithm
// Big-O notation: O(n^2)

// Demo
var arr = new int[] { 84, 21, 47, 96, 15 };
var arr2 = new int[] { 84, 21, 47, 96, 15, 11, 19, 0, 1, 6, 2, 8, 10, 23, 86, 55, 76, 33 };

BubbleSort(arr, arr.Length);
ImprovedBubbleSort(arr2, arr2.Length);

foreach (var number in arr)
    Console.Write($"{number} ");

Console.WriteLine();

foreach (var number in arr2)
    Console.Write($"{number} ");

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

void ImprovedBubbleSort(int[] arr, int length) // This version is O(n) in best case scenario
{
    bool swapped = true;

    for (int i = 0; i < arr.Length && swapped; i++)
    {
        swapped = false;
        
        for (int j = 0; j < length - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                swapped = true;
            }
        }
    }
}