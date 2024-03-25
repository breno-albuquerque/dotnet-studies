// Shell Sort
// Big-O notation: O(n^2)

// Demo
var arr = new int[] { 84, 21, 47, 96, 15, 94, 80, 17, 1, 43, 54 };

ShellSort(arr, arr.Length);

foreach (var i in arr)
    Console.WriteLine(i);

void ShellSort(int[] arr, int length)
{
    var gap = length / 2;

    while (gap > 0)
    {
        for (int i = gap; i < length; i++)
        {
            int anchor = arr[i]; 
            int j = i; 
            
            while (j >= gap && arr[j - gap] > anchor)
            {
                arr[j] = arr[j - gap];
                j -= gap;
            }

            arr[j] = anchor;
        }

        gap /= 2;
    }
}