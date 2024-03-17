// Binary Search
// Big-O notation: O(log n)

// Array needs to be in sorted order
var arr = new int[] { 15, 21, 47, 96, 108, 297 };

Console.WriteLine(RecursiveBinarySearch(arr, 21, 0, arr.Length - 1));
Console.WriteLine(RecursiveBinarySearch(arr, 108, 0, arr.Length - 1));
Console.WriteLine(RecursiveBinarySearch(arr,  297, 0, arr.Length - 1));


int RecursiveBinarySearch(int[] arr, int element, int start, int end)
{
    if (start > end)
        return -1;
    
    int mid = (end + start) / 2;
    
    if (element == arr[mid])
        return mid;
    
    if (element > arr[mid])
        return RecursiveBinarySearch(arr, element, mid + 1, end);
    
    if (element < arr[mid])
        return RecursiveBinarySearch(arr, element, start, mid - 1);

    return -1;
}