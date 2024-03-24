// Shell Sort
// Big-O notation: O(n^2)

// Demo
var arr = new int[] { 84, 21, 47, 96, 15, 94, 80, 17, 1, 43, 54 };

ShellSort(arr, arr.Length);

foreach (var i in arr)
    Console.WriteLine(i);

void ShellSort(int[] arr, int length)
{
    int gap = length / 2;

    while (gap > 0)
    {
        int i = gap;

        while (i < length)
        {
            int temp = arr[i]; 
            int j = i - gap; 

            while (j >= 0 && arr[j] > temp)
            {
                arr[j + gap] = arr[j];
                j -= gap;
            }

            arr[j + gap] = temp;
            i++;
        }

        gap /= 2;
    }
}