using System.Diagnostics;

var random = new Random();

// generate list
var list = new List<int>(5000);
list.AddRange(Enumerable.Range(1, 3000).Select(_ => random.Next(1, 3000)));
var toOrder = list.ToArray();

// clock
var clock = new Stopwatch();

// Benchmark MergeSortVsBubbleSort
clock.Start();
var mergeSortResult = MergeSort(toOrder);
clock.Stop();

Console.WriteLine("Merge Sort Nanoseconds");
Console.WriteLine(clock.Elapsed.Nanoseconds);

clock.Reset();

// Benchmark BubbleSort
clock.Start();
var bubbleSortResult = BlubleSort(toOrder);
clock.Stop();

Console.WriteLine("Bubble Sort Nanoseconds");
Console.WriteLine(clock.Elapsed.Nanoseconds);

int[] MergeSort(int[] arr)
{
    var length = arr.Length;

    if (length <= 1)
        return arr;

    var half = length / 2;

    // break in 2
    var left = new int[half];
    var right = new int[length - half];

    for (int i = 0; i < half; i++)
        left[i] = arr[i];
    for (int i = half; i < length; i++)
        right[i - half] = arr[i];

    // recursive
    var leftSorted = MergeSort(left);
    var rightSorted = MergeSort(right);

    // merge
    int leftIndex = 0, rightIndex = 0, sortedIndex = 0;
    int[] sorted = new int[leftSorted.Length + rightSorted.Length]; 

    while (sortedIndex < sorted.Length)
    {
        if (rightIndex >= rightSorted.Length)
        {
            sorted[sortedIndex] = leftSorted[leftIndex];
            leftIndex++;
        }
        else if (leftIndex >= leftSorted.Length)
        {
            sorted[sortedIndex] = rightSorted[rightIndex];
            rightIndex++;
        }
        else if (leftSorted[leftIndex] < rightSorted[rightIndex])
        {
            sorted[sortedIndex] = leftSorted[leftIndex];
            leftIndex++;
        }
        else
        {
            sorted[sortedIndex] = rightSorted[rightIndex];
            rightIndex++;
        }

        sortedIndex++;
    }

    return sorted;
}

static int[] BlubleSort(int[] arr)
{
    int length = arr.Length;
 
    for (int i = length - 1; i >= 1; i--)
    {
        for (int j = 0; j < i; j++)
        {
            if (arr[j] > arr[j + 1])
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
        }
    }
    return arr;
}