// Quick Sort

// Demo
int[] arr = [50, 25, 92, 16, 76, 30, 43, 54, 19];

QuickSort(arr, 0, arr.Length - 1);

foreach (var item in arr)
    Console.Write($"{item} ");

void QuickSort(int[] arr, int left, int right)
{
    if (arr.Length <= 1)
        return;

    if (left < right)
    {
        int pivot = Partition(arr, left, right);
        QuickSort(arr, left, pivot - 1);
        QuickSort(arr, pivot + 1, right);
    }
}

int Partition(int[] arr, int left, int right)
{
    int pivot = left;

    while (left < right)
    {
        while (arr[left] <= arr[pivot]) 
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
    (arr[first], arr[second]) = (arr[second], arr[first]);
}