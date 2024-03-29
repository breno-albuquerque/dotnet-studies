// Quick Sort

// Demo
int[] arr = [50, 25, 92, 16, 76, 30, 43, 54, 19];
int[] arr2 = [11, 9, 29, 7, 2, 15, 28];

QuickSort(arr, 0, arr.Length - 1);
QuickSort(arr2, 0, arr2.Length - 1);

foreach (var item in arr)
    Console.Write($"{item} ");

Console.WriteLine();

foreach (var item in arr2)
    Console.Write($"{item} ");

void QuickSort(int[] arr, int left, int right)
{
    if (left >= right)
        return;
    
    int pivot = Partition(arr, left, right);
    QuickSort(arr, left, pivot - 1);
    QuickSort(arr, pivot + 1, right);
}

int Partition(int[] arr, int left, int right)
{
    int pivot = left;

    while (left < right)
    {
        while (left < arr.Length && arr[left] <= arr[pivot]) 
            left++;

        while (arr[right] > arr[pivot])
            right--;

        if (right > left)
            Swap(left, right, arr);
    }

    Swap(right, pivot, arr);

    return right;
}

void Swap(int first, int second, int[] arr)
{
    if (arr[first] != arr[second])
        (arr[first], arr[second]) = (arr[second], arr[first]);
}