// Binary Search
// Big-O notation: O(log n)

// Array needs to be in sorted order
var arr = new int[] { 15, 21, 47, 96, 108, 297 };

Console.WriteLine(IterativeBinarySearch(arr, arr.Length, 21));
Console.WriteLine(IterativeBinarySearch(arr, arr.Length, 108));
Console.WriteLine(IterativeBinarySearch(arr, arr.Length, 297));


int IterativeBinarySearch(int[] arr, int length, int element)
{
    int start = 0;
    int end = length - 1;
    
    while (start <= end)
    {
        int mid = (end + start) / 2;

        if (element == arr[mid])
            return mid;

        if (element > arr[mid])
            start = mid + 1;
        else if (element < arr[mid])
            end = mid - 1;
    }

    return -1;
}